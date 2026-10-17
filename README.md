# Simulateur de Jeu de Rôle — Windows Forms

Application desktop en C# / Windows Forms permettant de créer des personnages, de gérer leur progression et de résoudre des épreuves grâce à des lancés de dés. Le projet embarque un moteur de règles complet (modificateurs de dés, pénalités de remplacement, réussites automatiques et paliers de difficulté) totalement dissocié de l'interface graphique.

## Principe et boucle de jeu

L'écran principal représente une salle où chaque personnage apparaît sous forme de figurine, avec trois zones d'action sur la droite. Tout se joue à la souris par **glisser-déposer (*drag & drop*)** :

1. **Création :** Génération d'un personnage (nom libre ou aléatoire) et répartition des points dans trois attributs de base : **Corps**, **Esprit** et **Sens**.
2. **Spécialisation :** Choix d'un *Plan* et d'une *Sphère* pour débloquer son arbre de compétences.
3. **Entraînement :** Glisser une figurine sur la zone d'entraînement ou cliquer dessus pour ouvrir sa fiche complète et dépenser ses points de compétence.
4. **Passage d'épreuves :** Déposer la figurine sur la zone d'**Auto-Éval** ou d'**Examen** pour lancer les dés et gagner de l'expérience en cas de réussite.

## Système de règles

### 1. Les trois indicateurs
Chaque personnage possède un score de **1 à 7** en **Corps**, **Esprit** et **Sens** (plafonné à 5 à la création). La valeur d'un indicateur détermine directement le **nombre de dés à 6 faces** lancés lors d'une épreuve liée à cet attribut.

### 2. Les 48 compétences et paliers de maîtrise
Sur les 48 compétences du jeu, chaque personnage en possède **16** :
- **8 compétences communes** à tous les personnages
- **4 compétences de Plan** (*Penseurs, Légats, Faiseurs, Intégrateurs, Commerçants*)
- **4 compétences de Sphère** (*Algèbre, Verbe, Transition, Création, Valorisation*)

Le niveau d'une compétence altère directement la valeur des faces des dés lancés et ajoute un bonus fixe au score total :

| Niveau | Rang | Modificateur sur les dés | Bonus fixe |
| :---: | :--- | :--- | :---: |
| **0** | Incompétent | *Utilise la meilleure compétence du même indicateur (malus de 2 crans de difficulté)* | — |
| **1** | Amateur | Les `1` valent `0` | +0 |
| **2** | Apprenti | Aucun modificateur | +5 |
| **3** | Compagnon | Les `6` valent `10` | +5 |
| **4** | Maître | Les `5` et `6` valent `10` | +10 |
| **5** | Agrégé | Les `4`, `5` et `6` valent `10` | +15 |
| **6** | Ministre | Les `4`, `5` et `6` valent `20` | +20 |

### 3. Résolution des épreuves
Deux formats d'épreuves sont disponibles :
- **Auto-Éval (épreuve ouverte) :** Le personnage lance autant de dés à 6 faces que son indicateur, applique les modificateurs de sa compétence, et le total détermine le palier de difficulté atteint.
- **Examen (épreuve fermée) :** Le seuil de difficulté est fixé à l'avance. Le personnage réussit s'il atteint ou dépasse le score cible (à haut niveau, certaines épreuves sont réussies ou ratées automatiquement sans jeter les dés).

**Seuils de difficulté :**
> **Trivial** (5) · **Facile** (10) · **Normal** (15) · **Complexe** (20) · **Délicat** (25) · **Défi** (30) · **Exploit** (50) · **Surhumain** (70) · **Impossible** (100)

## Architecture du projet

Le code sépare strictement la logique métier de l'affichage Windows Forms. Le moteur de règles n'a aucune dépendance envers les fenêtres et pourrait tourner tel quel dans une application console :

- **Moteur de règles (Modèle) :** Contient les entités (fiches de personnages, plans, sphères, compétences, indicateurs) et toute la logique de résolution (calcul des jets, transformation des faces de dés, gestion des pénalités d'incompétence et validation des seuils).
- **Salle principale (Vue) :** Gère le rendu des figurines, les événements de *drag & drop* vers les zones d'action et le routage vers les différentes fenêtres.
- **Fenêtres de création, fiche et épreuves (Vues) :** Formulaires de saisie, répartition des points et interface de lancement de dés qui interrogent le moteur de règles et affichent les résultats.

## Lancer le projet

Prérequis : **Visual Studio** (ou le SDK .NET avec support Windows Forms sous Windows).

```bash
git clone https://github.com/rafael-hocquel/PU-developpement-applicatif.git
cd PU-developpement-applicatif
dotnet run
