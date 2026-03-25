### Opis projektu:
Aplikacja przedstawia prosty system do zarządzania wypożyczaniem sprzętu (np. laptopów, projektorów, kamer).
Umożliwia:

* dodawanie użytkowników i sprzętu,
* wypożyczanie i zwracanie sprzętu,
* kontrolę dostępności,
* naliczanie kar za opóźnienia,
* generowanie podstawowych raportów.

### Struktura projektu:
Klasy główne:
* `Equipment` (abstracyjna) - baza dla sprzętu
  * `Laptop`
  * `Projector`
  * `Camera`
* `User` (abstrakcyjna) - baza dla użytkowników
  * `Student`
  * `Employee`
* `Renting` - reprezentuje wypożyczenie
* `Service`  - logika biznesowa systemu

### Kohezja (spójność):
Każda klasa ma jedną, konkretną odpowiedzialność:
* `Equipment` – przechowuje dane sprzętu
* `User` – przechowuje dane użytkownika i limit wypożyczeń
* `Renting` – obsługuje pojedyncze wypożyczenie i karę
* `Service` – zarządza operacjami (wypożyczenia, zwroty, raporty)

Dzięki temu kod jest czytelny i łatwy do utrzymania.

### Coupling (powiązania):
Zależności między klasami są ograniczone:
* tylko `Service` zarządza innymi klasami
* klasy `User`, `Equipment`, `Renting` nie są ze sobą bezpośrednio powiązane

Zmniejsza to sprzężenie i ułatwia rozwój projektu.

### Odpowiedzialności klas:
* `Service` → logika biznesowa
* `Renting` → stan wypożyczenia i naliczanie kar
* `User` → limit wypożyczeń (polimorfizm)
* `Equipment` → dostępność sprzętu

### Dlaczego taki podział?

Taki podział został wybrany, ponieważ:
* oddziela dane od logiki (większa czytelność),
* umożliwia łatwe rozszerzanie (np. nowy typ sprzętu),
* ogranicza duplikację kodu (dziedziczenie),
* upraszcza testowanie i rozwój.