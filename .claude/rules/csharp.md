---
paths:
  - "**/*.cs"
---

# C#-Stil

- APIs nutzen Controller. Die Schichten sind Controller, Service, Repository, und jede Schicht spricht nur mit der darunter.
- Fehler werden als Exceptions geworfen und zentral in ProblemDetails übersetzt, nicht in jedem Controller einzeln.
- Klassischer Stil: private Felder mit `_`-Präfix, explizite Konstruktoren, Klassen statt records.
- Ausnahme sind die DTOs der Web-APIs: Sie sind records und enden auf `Model`, zum Beispiel `ProductModel` oder `CreateOrderModel`.
- Methodennamen bekommen nie das Suffix `Async`, auch wenn sie einen Task zurückgeben: `GetById`, nicht `GetByIdAsync`.
- Zeit kommt immer aus einem injizierten `TimeProvider`, nie aus `DateTime.Now` oder `DateTimeOffset.UtcNow`. Zeitpunkte sind immer `DateTimeOffset`, nie `DateTime`.
- Geloggt wird nur über `[LoggerMessage]`-Methoden, nie direkt über `_logger.LogInformation(...)` und Co. Die Logging-Methoden stehen oben am Anfang der Klasse, vor Feldern und Konstruktor, die Klasse ist dafür `partial`.
- Konfiguration läuft nur über das Options-Pattern, nie über `IConfiguration["..."]` im Code. Jede Options-Klasse implementiert `IValidatedOptions` mit ihrer `SectionName`, prüft Pflichtwerte mit DataAnnotations wie `[Required]` und wird mit `builder.AddValidatedOptions<TOptions>()` registriert. Fehlende Werte stoppen den Service so beim Start. Gelesen wird über `IOptions<T>`, nicht `IOptionsMonitor<T>`, weil Umgebungsvariablen sich zur Laufzeit nicht ändern.
- Das gilt auch für Connection Strings: Jede Datenbank hat eine Options-Klasse wie `PortalDatabaseOptions`, die `IDatabaseOptions` mit `SectionName` `ConnectionStrings` und einer Konstante `ConnectionName` implementiert. Registriert wird sie mit `builder.AddNpgsqlDatabase<TContext, TOptions>()`.
- Keine Magic Strings und keine Magic Numbers. Literale wie Namen, Pfade, Schlüssel, Grenzwerte oder Exit-Codes stehen als benannte Konstante an genau einer Stelle und werden überall von dort referenziert. Die Namen der Aspire-Ressourcen stehen in `ResourceNames` im AppHost. Ausgenommen sind Ressourcen-Schlüssel in Razor wie `Localizer["Title"]`.
- Namespaces folgen dem Projekt, also `Chandlery.Catalog.Api`, `Chandlery.Ordering.Api` usw.
- Bezeichner und Kommentare auf Englisch. Jede öffentliche Methode sollte eine Summary haben. Kommentare in Code sollten sparsam sein, nur bei nicht-trivialen Dingen.
