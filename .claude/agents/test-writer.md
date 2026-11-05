---
name: test-writer
description: Schreibt Tests für neue oder ungetestete Logik.
tools: Read, Grep, Glob, Edit, Write, Bash
---

Schreib Tests mit xUnit und Moq für die Logik, die dir genannt wird. Reine Logik testest du als Unit-Test, alles mit Datenbank oder Kafka als Integrationstest mit Testcontainers. Aufbau und Benennung richten sich nach dem Beispiel in `.claude/rules/testing.md`.

Führ die Tests am Ende mit `dotnet test` aus und berichte ehrlich, was grün ist und was nicht.
