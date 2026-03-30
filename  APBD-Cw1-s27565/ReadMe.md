# README

## Instrukcja uruchomienia

Dla testowania działania aplikacji wystarczy uruchomić plik `Program.cs`, który tworzy testowe instancje obiektów i symuluje testowe przypadki. Wyniki działania programu są widoczne w konsoli.

## Opis zastosowanych rozwiązań

### Kohezja i odpowiedzialności klas

Kohezję, czyli spójną i konkretną odpowiedzialność klasy, można prześledzić na przykładzie klas `EquipmentService`, `RentalService` i `ReportService`. Każda z tych klas ma swój obszar działania.

`EquipmentService` przechowuje w sobie ekstensję obiektów sprzętu i odpowiada za dodawanie sprzętu, zmianę jego statusu oraz uzyskiwanie informacji o sprzęcie.

`RentalService` przechowuje ekstensję obiektów wypożyczeń i odpowiada za dodawanie wypożyczeń, zwracanie sprzętu oraz uzyskiwanie informacji o wypożyczeniach.

`ReportService` odpowiada za generowanie raportów. Jest to raczej klasa techniczna niż biznesowa.

Na potrzeby funkcjonalności aplikacji zostały stworzone także `EquipmentService`, `RentalService` i `UserService`, co pozwoliło nie umieszczać tej funkcjonalności bezpośrednio w modelach.

### Coupling

Coupling został ograniczony między innymi przez to, że raport jest generowany w oddzielnej klasie, a nie na przykład w `EquipmentService` albo bezpośrednio w `Program.cs`.

Klasa `EquipmentService` odpowiada za sprzęt i informacje o nim, ale nie bierze na siebie obowiązków związanych z wypożyczaniem. Podobnie `RentalService` odpowiada za logikę wypożyczeń, a nie za zarządzanie całym sprzętem czy generowanie raportów.

Dzięki temu klasy nie przejmują nadmiarowych odpowiedzialności i są od siebie mniej zależne.

### Dziedziczenie

W projekcie zostało użyte dziedziczenie w przypadku użytkowników `Student` i `Employee`. Obecnie klasy te różnią się tylko jednym atrybutem, ale takie rozwiązanie pozwala łatwo rozszerzyć je w przyszłości o kolejne cechy bez potrzeby zmiany całej struktury rozwiązania.

Dziedziczenie zostało również zastosowane dla klas związanych ze sprzętem, czyli `Equipment` i jego klas pochodnych. Wynika to z tego, że różne typy sprzętu posiadają własne atrybuty, których nie mają inne typy sprzętu.

### Enum statusu sprzętu

W projekcie został dodany `enum` opisujący status sprzętu. Teoretycznie aktualny stan mógłby zostać zapisany przy pomocy wartości typu `bool`, jednak zastosowanie `enum` daje większe możliwości rozwoju rozwiązania.

Dzięki temu w przyszłości można w prosty sposób dodać kolejne statusy sprzętu, bez konieczności zmiany samej idei przechowywania stanu. Takie podejście jest bardziej elastyczne i lepiej przygotowuje projekt na dalsze rozszerzenia.