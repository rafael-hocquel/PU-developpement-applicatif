# Un jeu de rôle avec Windows Forms

Créez et entraînez vos personnages, lancez des dés pour monter en compétence .

**Auteurs :** Rafaël HOCQUEL · Luc LAIGNEL · Lucas HAMPE GARRIDO
**Version :** 1.0 - avril 2026

## Le jeu

| Étape | Ce que l'on fait |
|-------|------------------|
| 1 | Créer un personnage : nom tiré au sort ou saisi, avec des valeurs aléatoires |
| 2 | Lui attribuer ses points : Corps, Esprit, Sens |
| 3 | Lui donner un plan et une sphère, qui déterminent 8 de ses compétences |
| 4 | L'entraîner, en dépensant ses points de compétence |
| 5 | Le faire passer une épreuve : glisser sa figurine sur la zone d'Auto-Éval ou d'Examen |
| 6 | Gagner de l'expérience à chaque épreuve réussie |

Le jeu applique les règles automatiquement : modificateurs de dés,
pénalités, réussites automatiques et seuils de difficulté.

## Les règles

### Les trois indicateurs

Un personnage vaut de 1 à 7 en **Corps**, **Esprit** et **Sens**, 5 au maximum
à la création. Sa valeur d'indicateur est aussi le nombre de dés qu'il lance
dans les épreuves qui en dépendent.

### Les 48 compétences

Chaque personnage en possède **16** : 8 compétences communes, 4 venant de son
**plan** (Penseurs, Légats, Faiseurs, Intégrateurs, Commerçants) et 4 venant de
sa **sphère** (Algèbre, Verbe, Transition, Création, Valorisation).

| Niveau | Nom | Modificateurs de dés | Bonus |
|--------|-----|----------------------|-------|
| 1 | Amateur | les 1 valent 0 | 0 |
| 2 | Apprenti | — | +5 |
| 3 | Compagnon | les 6 valent 10 | +5 |
| 4 | Maître | les 5 et 6 valent 10 | +10 |
| 5 | Agrégé | les 4, 5 et 6 valent 10 | +15 |
| 6 | Ministre | les 4, 5 et 6 valent 20 | +20 |

Une compétence non maîtrisée (niveau 0, « Incompétent ») n'est pas perdue : le
personnage utilise la meilleure compétence du même indicateur, mais avec une
**pénalité de deux crans** sur la difficulté.

### Les épreuves

- **Auto-Éval (épreuve ouverte)** : le personnage lance autant de dés à six
  faces que sa valeur d'indicateur, chaque dé est modifié par son niveau de
  compétence, et le total donne la difficulté atteinte.
- **Examen (épreuve fermée)** : la difficulté est fixée à l'avance, et l'épreuve
  est réussie si le personnage l'atteint. À haut niveau, certains examens se
  décident sans lancer les dés.

| Difficulté | Score | Difficulté | Score | Difficulté | Score |
|------------|-------|------------|-------|------------|-------|
| Trivial | 5 | Facile | 10 | Normal | 15 |
| Complexe | 20 | Délicat | 25 | Défi | 30 |
| Exploit | 50 | Surhumain | 70 | Impossible | 100 |

## Comment on joue

L'écran principal est une salle : chaque personnage y est représenté par une
figurine, et trois zones d'action sont dessinées à droite. Il suffit de
**glisser une figurine** sur une zone pour l'entraîner ou la faire passer une
épreuve. Un clic sur une figurine ouvre sa fiche complète, où les points se
répartissent.

## Comment ça marche

Le jeu sépare complètement ce qui se passe à l'écran et les règles : la partie
règles ne connaît aucune fenêtre, elle pourrait être réutilisée telle quelle
pour une version en ligne de commande.

| Partie | Contenu | Rôle |
|--------|---------|------|
| La salle | Les figurines des personnages, les trois zones d'action | Ouvre la création, l'édition ou l'épreuve selon ce que l'on clique ou dépose |
| Création et édition | Nom, plan, sphère, répartition des points d'indicateurs et de compétences | Remplit la fiche d'un personnage |
| Fiche, entraînement, épreuve | La fiche complète, l'entraînement, le jet d'épreuve | Lit et modifie la fiche, puis demande une épreuve aux règles |
| Les règles | La fiche, les épreuves, et les plans, sphères, compétences, indicateurs et difficultés | Calcule tout : modificateurs, pénalités, seuils atteints |
