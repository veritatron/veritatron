# Veritatron

Veritatron ist meine persönliche Webseite unter `veritatron.de`. Sie hat zwei Aufgaben: Sie ist mein Portfolio und stellt mich als Entwickler vor, und sie ist die Dachwebseite für alle meine Unterwebseiten, zu denen sie führt und denen sie einen gemeinsamen Einstieg gibt.

Die Unterwebseiten sind eigene Projekte außerhalb dieses Repos. Veritatron kennt sie nur über Name, Kurzbeschreibung und Adresse aus der Konfiguration und verlinkt auf sie. Es ruft keine Unterwebseite auf und referenziert keinen Code aus ihnen.

## Inhalte

- **Start / Über mich:** wer ich bin, was ich mache und meine fachlichen Schwerpunkte.
- **Projekte:** die Unterwebseiten und weitere Projekte, etwa GitHub-Repos, jeweils mit Name, Kurzbeschreibung und Link. Die Liste ist Konfiguration, kein Code.
- **Kontakt:** Links zu GitHub (`veritatron`) und weiteren Kanälen, kein Kontaktformular.
- **Impressum und Datenschutzerklärung:** eigene Seiten, aus jeder Seite im Footer erreichbar.

Die Website ist auch ein Arbeitsnachweis: Aufbau, Deployment und Betrieb sollen zeigen, wie ich Software baue und betreibe.

Datenschutz: Die Website lädt nichts von Drittanbietern. Schriften, Icons und Skripte werden selbst ausgeliefert, also auch keine Google Fonts. Es gibt kein Tracking und keine Cookies außer technisch notwendigen.

## Aufbau

Veritatron besteht nur aus zwei Projekten: einem Aspire-AppHost und einem Blazor-Projekt. Es ist kein Microservice-Projekt, weitere Services, Datenbanken oder Message Broker kommen nicht dazu.

```
Veritatron/
├── src/
│   ├── Veritatron.AppHost/        startet die Website lokal mit .NET Aspire
│   └── Veritatron.Web/            die Website, Blazor mit MudBlazor
├── tests/
│   └── Veritatron.Web.Tests/
├── deploy/                        Deployment-Artefakte je Umgebung
├── .github/workflows/
├── Directory.Build.props
├── Directory.Packages.props
├── global.json
└── Veritatron.slnx
```

- `Veritatron.AppHost` startet `Veritatron.Web` und reicht die Konfiguration als Umgebungsvariablen und Aspire-Parameter weiter. Die Namen der Aspire-Ressourcen stehen in `ResourceNames`.
- `Veritatron.Web` ist die Website mit Layout, Seiten, Komponenten, Theme und allem technischen Unterbau wie Health Checks, OpenTelemetry und Options-Validierung. Es gibt kein eigenes `ServiceDefaults`-Projekt.
- Die Liste der Unterwebseiten und Projekte ist Konfiguration, kein Code: Ein neuer Eintrag kommt in die Konfiguration, nicht ins Markup.

## Bereitstellung

Produktiv läuft Veritatron unter `veritatron.de`. Die Website läuft auf Kubernetes, mit Docker Compose und mit Podman. Nichts darf von einer dieser Umgebungen abhängen.

- `Veritatron.Web` wird zu einem OCI-Image, gebaut mit dem Container-Support des .NET SDK (`dotnet publish -t:PublishContainer`), ohne eigenes Dockerfile. Das Image läuft als Non-Root-User.
- Konfiguration kommt nur über Umgebungsvariablen und Aspire-Parameter, nie über Dateien, die in einer Umgebung fehlen könnten. Im Code wird sie über Options-Klassen gelesen, die beim Start validiert werden. Der Name der Umgebungsvariable folgt aus dem Options-Pfad und ist in AppHost, Compose und Helm derselbe. Die Website ist zustandslos.
- Health Checks: `/alive` für die Liveness, `/health` für die Readiness. Kubernetes nutzt sie als Probes, Compose als `healthcheck`.
- Die Website beendet sich sauber bei `SIGTERM`.
- Die Compose-Datei unter `deploy/compose/` erzeugt der AppHost mit `aspire publish` (`Aspire.Hosting.Docker`). Sie muss mit `docker compose` und `podman compose` laufen, also keine Docker-spezifischen Erweiterungen.
- Für Kubernetes gibt es ein von Hand gepflegtes Helm-Chart unter `deploy/helm/veritatron/` mit Deployment, Service und `HTTPRoute` (Gateway API, TLS über cert-manager, kein klassisches Ingress). Werte pro Umgebung stehen in `values-<umgebung>.yaml`, der Hostname `veritatron.de` in den Produktivwerten. Secrets stehen nie darin. Ändert sich die Konfiguration im AppHost, wird das Chart im selben Commit angepasst.
- Lokal läuft Aspire mit Docker oder Podman. Für Podman wird `ASPIRE_CONTAINER_RUNTIME=podman` gesetzt.
- CI liegt unter `.github/workflows/`.

## Code und Tests

Den Code-Stil beschreibt `.claude/rules/csharp.md`, den Aufbau von Tests `.claude/rules/testing.md`. Was sich automatisch prüfen lässt, steht in `.editorconfig` und `Directory.Build.props`. Neuer Code soll ohne Warnungen bauen.

Paketversionen stehen zentral in `Directory.Packages.props`, die Projekte nennen nur den Paketnamen. Die SDK-Version legt `global.json` fest.

```
dotnet build
dotnet test
dotnet run --project src/Veritatron.AppHost
dotnet format --verify-no-changes
```

## Arbeitsweise

Paketversionen nicht raten, sondern vorher mit `dotnet package search <name>` oder auf nuget.org nachsehen. Neue Abhängigkeiten nur nach Rückfrage. Jede Änderung endet mit grünem Build und einem AppHost, der startet.

Bezeichner, Code-Kommentare und Commit-Messages sind englisch, Dokumentation und Texte auf der Website sind deutsch. Website-Texte stehen nie im Markup, sondern in einer `.resx` neben der Komponente und werden über `IStringLocalizer<T>` gelesen. Die `.resx` ohne Sprachkürzel ist deutsch, jede weitere Sprache aus `SupportedCultures` bekommt eine eigene Datei wie `Page.en.resx`. Farben kommen nur aus `VeritatronColors` und `VeritatronTheme`, Stylesheets nutzen nur die CSS-Variablen von MudBlazor wie `var(--mud-palette-primary)` und nie Farbwerte. Commits folgen Conventional Commits, etwa `feat(web): ...` oder `chore(apphost): ...`. Secrets gehören nicht ins Repo, lokal kommen sie über Aspire-Parameter oder User Secrets. `appsettings.Development.json` wird nie gelesen oder ausgegeben, auch nicht über die Shell.

Für Reviews, Tests und Erklärungen gibt es Agents in `.claude/agents/`.
