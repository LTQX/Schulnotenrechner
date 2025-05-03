# Schulnotenrechner

Ein Rechner zur Eingabe gewichteter Noten mit der Möglichkeit, das Ergebnis als PDF-Datei zu exportieren.

Mit diesem Programm kann man jeweils Noten für die IMS-Fächer eingeben und dazu noch die Gewichtung.  
Das bedeutet: Die Note z. B. 5 mit der Gewichtung von 80 Prozent wäre in diesem Fall `5:80`.  
Das wäre die korrekte Eingabe.

Dies kann man beliebig oft pro Fach machen.  
Die Minuspunkte nach dem IMS-System wurden auch implementiert.  
Das bedeutet, die Anwendung weiß, dass man keine Pluspunkte, aber Minuspunkte haben kann, und berechnet dies automatisch.

Wenn man am Schluss alle Noten eingegeben hat, gibt die Anwendung die Ergebnisse mit dem Gesamtdurchschnitt und der Anzahl Minuspunkte aus.  
Danach trifft man auf die Frage, ob man das Ergebnis als PDF exportieren will.  
Wenn ja, wird es auf dem Desktop gespeichert, und wenn nicht, sieht man es in der Konsolenanwendung.  
Man kann dann entweder einen neuen Durchschnitt berechnen oder das Programm schließen.
