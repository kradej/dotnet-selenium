# Test case 1

Środowisko Testowe:
Selenium .Net ver 8

Warunki wstępne:
- działająca przeglądarka internetowa;
- dostęp do internetu;
- działająca strona: https://www.google.pl/

Kroki do wykonania:
1. Wejście na stronę: https://www.google.pl
2. Zamknięcie komunikatu dotyczącego plików cookie
3. Wpisanie w pasek wyszukiwania frazy 'selenium'
4. Wciśnięcie klawisza 'Enter'
5. Wybranie jednego z wyników wyszukiwania
6. Sprawdzenie, czy w tytule lub opisie występuje fraza 'Selenium'.

Oczekiwany wynik: W tytule bądź opisie wybranego wyniku wyszukiwania występuje fraza 'Selenium'.

# Test case 2

Środowisko Testowe:
Selenium .Net ver 8

Warunki wstępne:
- działająca przeglądarka internetowa;
- dostęp do internetu;
- działająca strona: https://www.google.pl/

Kroki do wykonania:
1. Wejście na stronę: https://www.google.pl
2. Zamknięcie komunikatu dotyczącego plików cookie
3. Wpisanie w pasek wyszukiwania frazy 'selenium'
4. Wciśnięcie klawisza 'Enter'
5. Wybranie jednego z wyników wyszukiwania i kliknięcie w tytuł strony (testowo: https://pl.wikipedia.org/wiki/Selenium)
6. Weryfikacja, czy w tytule wyszukiwanego hasła występuje fraza 'Selenium'.
7. Weryfikacja, czy w opisie wyszukiwanego hasła występuje fraza 'Selenium'.

Oczekiwany wynik: W tytule bądź opisie wybranej strony występuje fraza 'Selenium'. Wystarczy jeden spełniony warunek z powyższych.

# Test case 3

Środowisko Testowe:
Selenium .Net ver 8

Warunki wstępne:
- działająca przeglądarka internetowa;
- dostęp do internetu;
- działająca strona: https://www.google.pl/

Kroki do wykonania:
1. Wejście na stronę: https://www.google.pl
2. Zamknięcie komunikatu dotyczącego plików cookie
3. Wpisanie w pasek wyszukiwania frazy 'selenium'
4. Wciśnięcie klawisza 'Enter'
5. Wybranie jednego z wyników wyszukiwania i kliknięcie w tytuł strony (testowo: https://pl.wikipedia.org/wiki/Selenium)
6. Weryfikacja, czy na stronie występują obrazy powiązane z frazą 'Selenium'.

Oczekiwany wynik: Na wybranej stronie występują obrazy powiązane z frazą 'Selenium'.