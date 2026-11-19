# AlgoTournament - Handleiding

In deze opdracht programmeer je in C# een eigen bot voor AlgoTournament. Tijdens een wedstrijd van 20 minuten spelen de bots tegen elkaar op een veld van 2000 bij 2000. Je groeit door voedselbolletjes te pakken en kleinere bots op te eten. De bot met de meeste massa aan het eind van de tijd wint.

## Overzicht van de Mappenstructuur

```text
📁 Algo-Student-Repo/
 ├── 📄 README.md                  <-- Deze handleiding
 ├── 🎯 AlgoBot.sln                <-- Dubbelklik hierop om het project in Visual Studio te openen
 │
 ├── 📁 Algo.API/                  <-- De spel-onderdelen (NIET AANPASSEN)
 ├── 📁 Algo.StarterBot/           <-- JOUW PROJECTMAP
 │    └── 💻 MyBot.cs              <-- ⭐ HIER PROGRAMMEER JE JOUW BOT!
 │
 └── 📁 Game/                      <-- Het spel waarmee je jouw bot lokaal kunt testen
      ├── 🚀 AlgoTournament.exe    <-- Start het spel (Sluiten = Alt + F4)
      ├── 📁 Bots/                 <-- ⭐ HIER PLAATS JE JOUW GECOMPILEERDE .DLL BESTAND!
      └── 📁 BotLogs/              <-- Hier verschijnen na het spelen de logbestanden van jouw bot
```

## 1. Project downloaden en openen

1. Klik rechtsboven op GitHub op de groene knop `<> Code` en kies `Download ZIP` (of clone de repository met Git).
2. Pak het zip-bestand eerst volledig uit naar een map op je laptop. Open de solution niet direct vanuit een onuitgepakte zip.
3. Dubbelklik op `AlgoBot.sln` om het project in Visual Studio te openen.
4. Open rechts in de Solution Explorer onder `Algo.StarterBot` het bestand `MyBot.cs`.

## 2. Je bot aanpassen (`MyBot.cs`)

In `MyBot.cs` staan twee methodes: `GetName()` en `Update(IGameContext context)`.

### Naam instellen
Vul bij `GetName()` je eigen naam of teamnaam in:
```csharp
public string GetName()
{
    return "TeamNaam";
}
```

### Spelregels en logica (`Update`)
Het spel roept meerdere keren per seconde jouw `Update`-methode aan om te vragen welke richting je bot op moet bewegen (`Vector2(x, y)`).

- **Het speelveld (2000 x 2000):** Als je aan de rechterkant het scherm uit loopt, kom je aan de linkerkant weer binnen (zelfde voor boven en onder). De game rekent posities van voedsel en tegenstanders al automatisch voor je om, dus je kunt gewoon met standaard X- en Y-coördinaten rekenen.
- **Snelheid:** Hoe groter je wordt, hoe langzamer je beweegt.
- **Andere bots opeten:** Je kunt een andere bot pas opeten als jouw massa minstens 10% groter is:
  - Tegenstander is gevaarlijk: `opponent.Mass > myMass * 1.1f` (vluchten)
  - Tegenstander is eetbaar: `myMass > opponent.Mass * 1.1f` (aanvallen)

### Beschikbare functies via `context`

| Functie | Omschrijving |
| :--- | :--- |
| `context.GetMyX()` / `context.GetMyY()` | Je huidige X- en Y-positie op het veld. |
| `context.GetMyMass()` | Je huidige massa. |
| `context.GetSightRadius()` | Hoe ver je bot kan kijken (`500f`). |
| `context.GetFoodInRange(500f)` | Lijst (`IEnumerable<EntityInfo>`) met voedsel in de buurt. Elk punt heeft `.X`, `.Y` en `.Mass`. |
| `context.GetOpponentsInRange(500f)` | Lijst (`IEnumerable<EntityInfo>`) met andere bots in de buurt. Elke bot heeft `.X`, `.Y` en `.Mass`. |
| `context.GetDistanceTo(target)` | Berekent de afstand tussen jou en een ander punt. |
| `context.GetDirectionTo(target)` | Geeft een `Vector2` richting naar het doelwit. |
| `context.GetDensestFoodTarget(food)` | Geeft het stukje voedsel terug waar het meeste andere voedsel omheen ligt. |

Wil je zelf een richting berekenen met X en Y:
- Richting een doel lopen: `float dirX = doel.X - myX;` en `float dirY = doel.Y - myY;`
- Wegrennen van een vijand: `float dirX = myX - vijand.X;` en `float dirY = myY - vijand.Y;`

## 3. De DLL compileren

Als je klaar bent met je aanpassingen in `MyBot.cs`, sla je het bestand op (`Ctrl + S`) en bouw je de DLL:

1. Klik bovenin Visual Studio op `Build` -> `Build Solution` (of gebruik `Ctrl + Shift + B`).
2. Controleer onderin het Output-venster of er `Build succeeded. 0 Error(s)` staat.
3. Het gecompileerde bestand staat nu in deze map:
   ```text
   Algo.StarterBot\bin\Debug\netstandard2.1\Algo.StarterBot.dll
   ```
   *(Staat je configuratie bovenin Visual Studio op Release in plaats van Debug, kijk dan in `bin\Release\netstandard2.1\`).*

## 4. Lokaal testen in de game

Om je bot te testen tegen de standaard bots:

1. Ga naar `Algo.StarterBot\bin\Debug\netstandard2.1\` en kopieer `Algo.StarterBot.dll`.
2. Plak het bestand in de map:
   ```text
   Game\Bots\
   ```
   *(Laat `DefaultOpponents.dll` en `AvatarSheet.png` in die map staan, dat zijn de oefen-bots en standaard afbeeldingen).*
3. **Optioneel - Eigen afbeelding:** Wil je een eigen afbeelding op je bot, zet dan een vierkante `.png` of `.jpg` met exact dezelfde naam als je DLL in `Game\Bots\` (bijvoorbeeld `TeamNaam.dll` en `TeamNaam.png`).
4. Start het spel door in de map `Game\` te dubbelklikken op `AlgoTournament.exe`.
5. Sluit het spel weer af met `Alt + F4`.

## 5. Logs bekijken (`BotLogs`)

Tijdens het spelen maakt de game voor elke bot een eigen map met logbestanden aan in:
```text
Game\BotLogs\<DLLNaam>_<BotNaam>\
```

In het bestand `ALL_CLONES_LOG.txt` (en de losse logs per kloon) wordt elke kill en death gelogd met:
- Het tijdstip en de `(X, Y)` coördinaten van jou en de tegenstander.
- Het verschil in massa op het moment van raken.
- De richting die je bot op liep (`My Last Move Direction`) en wat op dat moment de juiste vluchtrichting was geweest (`Ideal Escape Direction`).

Gebruik die gegevens om te controleren of je bot de juiste beslissingen neemt.

## 6. Inleveren

Voor het toernooi op het grote scherm in de klas:
1. Hernoem je gecompileerde `Algo.StarterBot.dll` naar je eigen naam of teamnaam (bijv. `TeamNaam.dll`).
2. Lever de `.dll` (en eventueel je gelijknamige `.png`) in bij de docent.
