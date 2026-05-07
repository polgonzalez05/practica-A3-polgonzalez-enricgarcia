L'Assetjament d'Ormuz (1622)


Al 1622 la fortalesa de Nossa Senhora da Vitória, a l'illa d'Ormuz, era la "clau" del Golf Pèrsic. Qui controlava Ormuz, controlava el flux d'espècies i seda cap a Europa i de les perles iranianes que eren un dels objectes més cobejats pels nobles. Fins al moment l'estret d'Ormuz i l'illa d'Ormuz estava controlada per la Unió Ibèrica una unió de facto entre la monarquia hispànica i el regne de Portugal.

El conflicte
El 1622, una aliança inusual va decidir expulsar els portuguesos i espanyols de la zona. L'imperi Safàvida (Pèrsia) volia recuperar el territori i el control comercial i per això es va aliar amb l'EIC (East Indian Company – Companyia Angleses de les Índies Orientals). L'EIC patrocinada indirectament per l'imperi britànic que oferia potència de foc naval mentre l'exercit persa atacava per terra.

Resolució

La falta de recursos enviats per la Unió Ibèrica van deixar quasi sol a en Rui Freire d'Andrarde que va acabar rendint la ciutat al Shah Abbas que va fundar la ciutat Bandar Abbas i va cedir el comerç i els aranzels a l'Imperi Britànic.



El joc
En el joc encarnes Rui Freire d'Andrade que intenta de la millor forma que pot defensar la fortalesa i la ciutat d'Ormuz mentre rep els atacs de l'imperi persa i dels navilis de la companyia de l'Índies orientals.



 Implementació
Player
Implementa una classe Player que dibuixi el militar Rui enmig de l'isme d'Ormuz. Aquesta classe ha de ser filla de StaticActor i s'ha de pintar a la capa Middle.
En un principi per a la imatge de Rui tria de forma aleatòria entre rui1, rui2 i rui3.
El player roman quiet al centre de l'illa i apunta sempre cap a la fletxa del ratolí.
Aquest player dispara cada vegada que es fa clic amb el botó esquerre del ratolí, però amb un CoolDown pre-establert que pots modificar amb la funció ChangeCoolDown.
El player té també una quantitat de HitPoints que van minvant quan rep impactes de les Bullets.
Bales
Cada vegada que dispara el jugador s'ha de fer una Bullet a uns pocs píxels del jugador i amb la mateixa direcció de cap a on apunta el jugador. Aquesta classe Bullet fa servir la imatge cannonBall.png
Aquesta bala es mou a velocitat constant Speed
Té un LifeTime que fa que alhora la bala desaparegui. (és a dir deixa de pintar-se i deixa d'existir com a actor)
Si la bala impacta contra un enemic fa un Damage que es resta dels HitPoints de l'enemic
Si una bala col·lisiona amb una altra bala totes dues s'anul·len i desapareixen.
Pirates
La classe Pirate implementa cadascun dels vaixells enemics que intenten atacar l'illa. La imatge pirata1.png representa els vaixells de l'EIC i la imatge pirata4.png representa els vaixells de l'exercit persa.
Aquesta classe és filla d 'Enemy, que té implementada una funció que té un Explosion quan es destrueix. Revisa la classe Explosion per entendre com funciona.
Aquests vaixells tenen diferents propietats que defineixen el seu comportament:
RotSpeed: Velocitat de rotació angular.
Speed: Velocitat de moviment.
CoolDown: Temps de descans entre dispar i dispar.
HitPoins: Punts de vida abans de ser destruïts.
Damage: Quantitat de dany que fan les seves bales en impactar
Quan els seus HitPoints arriben a 0 el vaixell i la bala que ha impactat es destrueix deixant un objecte de tipus Explosion al seu lloc.
Aquests vaixells es poden moure per qualsevol punt de la pantalla excepte entrar a l'illa.
PirateSpawner
La classe PirateSpawner ha de fer aparèixer pirates cada cert temps.
Aquests pirates s'han de fer en punts aleatoris de la pantalla evitant la zona central de l'illa.
Comportament dels Pirates
 Jugant amb les 5 propietats de les naus pirates podem configurar diferents comportaments i característiques
Els vaixells perses (verds) tenen una potència de foc menor (CoolDown i Damage) i una velocitat menor (RotSpeed i Speed)
Implementa una maquina d’estats amb tres estats diferents per al comportament del vaixells anglesos:
El primer estat van lents amb una direcció aleatòria i una velocitat lenta
Quan han passat 5 segons incrementen la seva velocitat i canvien el seu rumb i comencen a disparar a una velocitat lenta també
Si per casualitat arriben a una distancia menor de 300 pixels de la illa canvien el rumb i incrementen la seva velocitat de dispar quan passen 10 segons tornen al primer estat
Hud
Crea una classe Hud que mostra la vida que queda a Rui i el nombre d'enemics vençuts
Escena i GameOver
En iniciar el Joc volem que surti la portada. Crea una classe Intro que mostri la portada en pantalla
Crea una altra classe GameOver que mostri una pantalla de GameOver
Crea un sistema d'estats a MyGame de manera que en iniciar es carrega l'estat d 'Intro mostrant tan sols la classe Intro
Quan es polsa espai apareix el joc i quan els vaixells pirates han acabat amb la vida de Rui es mostra durant uns segons la classe GameOver per tornar al principi
  

Qualificació
La suma de la puntuació dels diferents apartats es multiplicarà per un factor individual de 0 a 1. Es a dir, que la suma de la nota dels diferents apartats no serà la nota final de la pràctica. Aquest factor de 0 a 1 vindrà donat per la nota del qüestionari que s'haurà de fer posterior a l'entrega de la pràctica i per la qualitat i cantitat dels commits a github.
