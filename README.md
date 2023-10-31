## Nøsted & Prosjekt Høsten 2023 - Gruppe 12

Beskrivelse av Prosjektet:

Funksjoner:
-  Kan opprette kundedata i "New Service" og sende det til "Kommende Service". Denne dataen skal senere sendes til databasen og hentes opp.
-  Hard kodet default kundedata på alle sidene
-  Har et multiple choice skjema som kan sende data. Dataen vises ingen sted enda, men om man åpner network så ser man den der. Å vise dataen vil være samme prosess som å vise       kundedataen.
-  Har en "falsk" log in funksjon som ikke har noe autorisering. Autorisering skal implementeres i neste oppgave.
      - Brukernavn: Admin
      - Passord: 123
-  I "Pågående Service" Så har vi kort som kundedataen går inn i, disse skal bli autogenererte i fremtiden. Dersom brukeren trykker på et kort, vil det ta dem videre til              serviceskjema nettsiden.
  
Fått til alle krav, men det er mye rot på nettsiden. Dette skal fikses i snar fremtid.

måtte kommentere ut følgende linje "response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval';");" fordi den forårsaket at css-stylesheets ikke fikk tilgang til filene. Det betyr at XSS ikke er 100% implementert

