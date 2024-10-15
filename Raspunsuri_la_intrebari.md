# 1. Ce este un viewport?
# Viewport-ul reprezinta o portiune a ferestrei de desenare in care se realizeaza randarea grafica. Este un dreptunghi care specifica cum se transforma coordonatele normale ale ferestrei pe axele x si y in coordonatele pixelilor ferestrei.
# 2. Ce reprezinta conceptul de frames per second (FPS) din punctul de vedere al bibliotecii OpenGL?
# Frames per second reprezinta numarul de cadre generate si afisate intr-o secunda. Masoara performantele aplicatiilor grafice, indicand cat de fluent este randat un joc sau o aplicatie.
# 3. Cand este rulata metoda OnUpdateFrame()?
# Metoda OnUpdateFrame() este apelata de fiecare data cand se face o actualizare a starii aplicatiei.
# 4. Ce este modul imediat de randare?
# Modul imediat de randare este o tehnica de randare folosita in OpenGL care permite trimiterea datele pentru grafica 3D direct catre GPU in timpul procesului de randare.
# 5. Care este ultima versiune de OpenGL care accepta modul imediat?
# Ultima versiune de OpenGL care accepta modul imediat de randare este OpenGL 2.1.
#  Cand este rulata metoda OnRenderFrame()?
# Metoda OnRenderFrame() este apelata la fiecare cadru pentru a efectua randarea grafica pe ecran.
# De ce este nevoie ca metoda OnResize() sa fie executata cel putin o data?
# Metoda OnResize() este folosita pentru a ajusta viewport-ul si perspectiva atunci cand dimensiunile ferestrei se schimba.
# 8. Ce reprezinta parametrii metodei CreatePerspectiveFieldOfView() si care este domeniul de valori pentru acestia?
# fieldOfView: unghiul de vizualizare care determina cat de mult din scena este vizibila. Valorile sunt intre 0 si pi/2.
# aspectRatio: raportul intre latimea si inaltimea ferestrei, care ajuta la corectarea distorsiunilor la redimensionare.
# nearPlane: distanta de la camera la planul cel mai apropiat care va fi vizibil, care trebuie sa fie o valoare pozitiva, de obicei mai mare decat 0.
# farPlane: distanta de la camera la planul cel mai indepartat care va fi vizibil, care trebuie sa fie mai mare decat nearPlane.