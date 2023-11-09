## Nøsted & Prosjekt Høsten 2023 - Gruppe 12

Beskrivelse av Prosjektet:

Funksjoner:
-  Kan sende ned  og slette kundedata til database fra "New Service". Dette hentes opp og vises på "Kommende service"
-  Har et multiple choice skjema som kan sende data. Dataen vises ingen sted enda, men om man åpner network så ser man den der. Å vise dataen vil være samme prosess som å vise       kundedataen.
-  Har en "falsk" log in funksjon som ikke har noe autorisering. Autorisering skal implementeres i neste oppgave.
      - Brukernavn: Admin
      - Passord: 123
-  I "Pågående Service" Så har vi kort som kundedataen går inn i, disse skal bli autogenererte i fremtiden. Dersom brukeren trykker på et kort, vil det ta dem videre til              serviceskjema nettsiden.
  
Fått til alle krav, men det er mye rot på nettsiden. Dette skal fikses i snar fremtid.

måtte kommentere ut følgende linje "response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval';");" fordi den forårsaket at css-stylesheets ikke fikk tilgang til filene. Det betyr at XSS ikke er 100% implementert.**(NÅ FIKSET)**

