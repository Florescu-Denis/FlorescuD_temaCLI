Care este ordinea de desenare a vertexurilor pentru aceste metode(orar sau anti-orar)?
anti-orar

Care este efectul rularii comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? Functioneaza in interiorul unei zone GL.Begin()?
GL.LineWidth(float) seteaza grosimea liniilor
GL.PointSize(float) seteaza dimensiunea diametrului unui punct
Ambele functioneaza in GL.Begin()

Care este efectul utilizarii directivei LineLoop atunci cand sunt desenate segmente de dreapta multiple in OpenGL?
Dupa ce sunt toate segmentele desenate, LineLoop conecteaza ultimul vertex cu primul

Care este efectul utilizarii directivei LineStrip atunci cand sunt desenate segmente de dreapta multiple in OpenGL?
Dupa ce sunt toate segmentele desenate, LineStrip conecteaza fiecare vertex este conectat la urmatorul, formand o linie continua

Care este efectul utilizarii directivei TriangleFan atunci cand sunt desenate segmente de dreapta multiple in OpenGL?
Directiva genereaza un set de triunghiuri, unde primul vertex este fix, iar celelalte triunghiuri sunt formate din primul vertex plus inca doua vertex-uri consecutive

Care este efectul utilizarii directivei TriangleStrip atunci cand sunt desenate segmente de dreapta multiple in OpenGL?
GL.TriangleStrip genereaza o secventa de triunghiuri conectate, in care fiecare triunghi, dupa primul, impartasete doua vertexuri cu triunghiul precedent, legandu-se unul de altul formand o banda 

Urmariti aplicatia "shapes.exe" din tutorii OpenGL Nate Robbins. De ce este importanta utilizarea de culori diferite (in gradient sau culori selectate per suprafata) in desenarea obiectelor 3D? Care este avantajul?
Culorile selectate pentru suprafete ne ajuta sa distingem mai bine obiectele 3D, gradientul ajuta la perceptia adancimilor unor obiecte 3D sau la efectele de iluminare
Avantajul este ca ajuta ochiul uman sa perceapa mai bine scena sau obiectele prin estetica acestora

Ce reprezinta un gradient de culoare? Cum se obtine acesta in OpenGL?
Un gradient de culoare reprezinta o tranzitie treptata intre doua sau mai multe culori diferite
In OpenGL dupa ce setam culorile pentru vertex-uri, OpenGL automat va forma un gradient

Ce efect va apare la utilizarea canalului de transparenta?
Nu se vede o schimabre

Ce efect are utilizarea unei culori diferite pentru fiecare vertex atunci cand desenati o linie sau un triunghi in modul strip?
Efectul consta in iterpolarea culorilor, formandu-se un gradient