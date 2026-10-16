# Les sprints du projet

Le projet est découpé en **7 sprints**. Chaque sprint a un objectif, des tâches, des livrables et des critères de validation : le sprint est réussi quand tous les critères sont vérifiés.

Les groupes du mercredi et du vendredi suivent le même planning. **Chaque sprint se termine le vendredi à 20 h** : ce qui est sur `main` à cette heure-là, avec l'étiquette de version, est présenté en revue à la séance suivante.

Les premiers sprints sont très guidés (TODO avec consigne et indice, exemples complets à côté). Au fil de l'année, les indices se font plus courts et certaines tâches n'ont plus de TODO.

## Calendrier

| Sprint | Dates | Séances du mercredi | Séances du vendredi | Fin du sprint | Version |
|---|---|---|---|---|---|
| 1 · Démarrer | Du lundi 12 octobre au vendredi 6 novembre 2026 (vacances de la Toussaint du 17 octobre au 1er novembre) | 14/10, 04/11 | 16/10, 06/11 | vendredi 6 novembre 2026, 20 h | `v0.1` |
| 2 · La vitrine | Du lundi 9 au vendredi 27 novembre 2026 (mercredi 11 novembre férié) | 18/11, 25/11 | 13/11, 20/11, 27/11 | vendredi 27 novembre 2026, 20 h | `v0.2` |
| 3 · Le panier · version 1 | Du lundi 30 novembre au vendredi 11 décembre 2026 (dernier jour avant le stage) | 02/12, 09/12 | 04/12, 11/12 | vendredi 11 décembre 2026, 20 h | `v1.0` |
| — | **Stage : du lundi 14 décembre 2026 au vendredi 15 janvier 2027 (vacances de Noël comprises).** | | | | |
| 4 · Reprise et commande | Du lundi 18 janvier au vendredi 5 février 2027 (veille des vacances d'hiver) | 20/01, 27/01, 03/02 | 22/01, 29/01, 05/02 | vendredi 5 février 2027, 20 h | `v1.1` |
| 5 · L'écran cuisine | Du lundi 22 février au vendredi 12 mars 2027 | 24/02, 03/03, 10/03 | 26/02, 05/03, 12/03 | vendredi 12 mars 2027, 20 h | `v1.2` |
| 6 · Suivi en direct et mise en ligne | Du lundi 15 au vendredi 26 mars 2027 | 17/03, 24/03 | 19/03, 26/03 | vendredi 26 mars 2027, 20 h | `v1.3` |
| 7 · Finaliser et présenter | Du lundi 29 mars au vendredi 2 avril 2027 (veille des vacances de printemps) | 31/03 | 02/04 | vendredi 2 avril 2027, 20 h | `v2.0` |

## Comment on travaille

| Quand | Quoi |
|---|---|
| Début de chaque séance | Point de séance (10 min), animé par le Scrum Master : fait, à faire, blocages. Compte rendu dans docs/scrum. |
| Première séance d'un sprint | Revue du sprint précédent (démonstration au Product Owner), rétrospective, puis planification du nouveau sprint. |
| Fin de chaque séance | 5 minutes : pousser son travail sur GitHub, mettre le tableau à jour. |
| Fin du sprint (vendredi 20 h) | Le Scrum Master pose l'étiquette de version sur main : sur GitHub, Releases → Create a new release → v0.1, v0.2… |

**Une tâche est terminée quand :**

1. elle respecte la consigne du TODO (ou les critères de la user story) ;
2. le site démarre et la page concernée fonctionne ;
3. les tests sont verts, sur le poste (dotnet test) et sur GitHub (coche verte) ;
4. la pull request a été relue et approuvée par un coéquipier, puis fusionnée dans main ;
5. le commentaire TODO a été supprimé et l'issue est fermée.

## Sprint 1 · Démarrer

**Niveau de guidage :** Très guidé  
**Dates :** Du lundi 12 octobre au vendredi 6 novembre 2026 (vacances de la Toussaint du 17 octobre au 1er novembre)  
**Séances :** mercredi 14/10, 04/11 · vendredi 16/10, 06/11  
**Fin du sprint :** vendredi 6 novembre 2026, 20 h, étiquette `v0.1`

**Objectif :** Le projet tourne sur le poste de chaque membre et la carte s'affiche à partir de la base de données.

### Tâches

- Le Scrum Master crée le dépôt de l'équipe à partir du squelette et invite ses coéquipiers.
- Chacun installe le projet en suivant le README (XAMPP, scripts SQL, fichier .env) ou ouvre un Codespace.
- Créer le tableau GitHub Projects de l'équipe, avec une issue par TODO du sprint.
- Faire les TODO S1-01 à S1-05 : une branche et une pull request relue par TODO.
- Accompagnement en séance : Rappel Git en début de première séance (branche, commit, pull request) ; installation pas à pas, tous ensemble.

| TODO | Fichier | À faire |
|---|---|---|
| S1-01 | `README.md` | Présenter votre équipe |
| S1-02 | `src/CroustyClickCollect/Views/Shared/_Layout.cshtml` | Signer le site avec le nom de votre équipe |
| S1-03 | `src/CroustyClickCollect/Data/ProduitRepository.cs` | Lire les produits de la carte dans la base |
| S1-04 | `src/CroustyClickCollect/Views/Carte/Index.cshtml` | Afficher le prix du produit |
| S1-05 | `src/CroustyClickCollect/Views/Home/Index.cshtml` | Écrire le texte de présentation de l'enseigne (V1) |

### Livrables

- Dépôt de l'équipe avec le README complété (équipe, ordre des Scrum Masters).
- Tableau GitHub avec les issues du sprint.
- Un compte rendu par séance dans docs/scrum.
- Version étiquetée v0.1.

### Critères de validation

- [ ] Sur le poste de chaque membre, l'accueil affiche « ✔ Base de données connectée : 9 produits trouvés ».
- [ ] La page « La carte » affiche les 9 produits avec leur prix au format 9,00 €.
- [ ] Chaque membre a au moins une pull request relue par un coéquipier puis fusionnée.
- [ ] La coche verte de GitHub Actions est présente sur main.

## Sprint 2 · La vitrine

**Niveau de guidage :** Très guidé  
**Dates :** Du lundi 9 au vendredi 27 novembre 2026 (mercredi 11 novembre férié)  
**Séances :** mercredi 18/11, 25/11 · vendredi 13/11, 20/11, 27/11  
**Fin du sprint :** vendredi 27 novembre 2026, 20 h, étiquette `v0.2`

**Objectif :** Un visiteur voit les restaurants, sait s'ils sont ouverts en ce moment et peut lire les pages légales.

### Tâches

- Première planification faite par l'équipe : choisir les TODO du sprint et se les répartir.
- Faire les TODO S2-01 à S2-04 : liste des restaurants, règle d'ouverture, tests, badge « Ouvert / Fermé ».
- Faire les TODO S2-05 à S2-07 : mentions légales, politique de confidentialité, conditions de vente.
- Conception : dessiner le MCD et le MLD de la base fournie (sql/01-schema.sql).
- Accompagnement en séance : Les requêtes SELECT (WHERE, ORDER BY) ; premier atelier sur les tests unitaires.
- Pour aller plus loin (facultatif) : V7 : carte géographique des restaurants.

| TODO | Fichier | À faire |
|---|---|---|
| S2-01 | `src/CroustyClickCollect/Data/RestaurantRepository.cs` | Lire tous les restaurants, triés par nom |
| S2-02 | `src/CroustyClickCollect/Services/HorairesService.cs` | Écrire la règle d'ouverture |
| S2-03 | `tests/CroustyClickCollect.Tests/HorairesServiceTests.cs` | Activer les tests des horaires |
| S2-04 | `src/CroustyClickCollect/Controllers/RestaurantsController.cs` | Indiquer pour chaque restaurant s'il est ouvert en ce moment |
| S2-05 | `src/CroustyClickCollect/Views/Home/MentionsLegales.cshtml` | Rédiger les mentions légales (V4) |
| S2-06 | `src/CroustyClickCollect/Views/Home/Confidentialite.cshtml` | Rédiger la politique de confidentialité (V4, RGPD) |
| S2-07 | `src/CroustyClickCollect/Views/Home/Cgv.cshtml` | Rédiger les conditions générales de vente (V4) |

### Livrables

- Version v0.2.
- MCD et MLD dans docs/conception.
- Les trois pages légales rédigées.
- Comptes rendus de séance et première rétrospective.

### Critères de validation

- [ ] « Nos restaurants » affiche les 3 restaurants avec le bon badge selon l'heure.
- [ ] Les 4 tests des horaires sont verts, sur le poste et sur GitHub.
- [ ] Plus aucun « [À compléter] » dans les pages légales ; l'hébergeur est cité.
- [ ] Le MCD correspond aux tables du script 01-schema.sql.

## Sprint 3 · Le panier · version 1

**Niveau de guidage :** Guidé  
**Dates :** Du lundi 30 novembre au vendredi 11 décembre 2026 (dernier jour avant le stage)  
**Séances :** mercredi 02/12, 09/12 · vendredi 04/12, 11/12  
**Fin du sprint :** vendredi 11 décembre 2026, 20 h, étiquette `v1.0`

**Objectif :** Le visiteur choisit son restaurant, remplit son panier, le modifie et voit le total à payer.

### Tâches

- Faire les TODO S3-01 et S3-02 : lire un produit, mémoriser le restaurant choisi.
- Faire les TODO S3-03 à S3-06 : ajouter au panier, calculer le total, retirer, 10 articles maximum.
- Faire les TODO S3-07 et S3-08 : bouton « Retirer », tests du panier.
- Conception : diagramme de classes du dossier Models.
- Chacun remplit sa note de reprise (docs/REPRISE.md) avant de partir en stage.
- Accompagnement en séance : La session (la « mémoire » du visiteur) ; les formulaires envoyés en POST et leur protection.
- Pour aller plus loin (facultatif) : C9 : modifier le panier sans recharger la page.

| TODO | Fichier | À faire |
|---|---|---|
| S3-01 | `src/CroustyClickCollect/Data/ProduitRepository.cs` | Lire UN produit à partir de son identifiant |
| S3-02 | `src/CroustyClickCollect/Services/PanierSession.cs` | Mémoriser le restaurant choisi par le visiteur (C1) |
| S3-03 | `src/CroustyClickCollect/Services/PanierService.cs` | Ajouter un article au panier (C2, C3) |
| S3-04 | `src/CroustyClickCollect/Services/PanierService.cs` | Calculer le total du panier (C4) |
| S3-05 | `src/CroustyClickCollect/Services/PanierService.cs` | Retirer une ligne du panier (C4) |
| S3-06 | `src/CroustyClickCollect/Services/PanierService.cs` | Appliquer la règle RG2 (10 articles maximum) |
| S3-07 | `src/CroustyClickCollect/Views/Panier/Index.cshtml` | Ajouter un bouton « Retirer » sur chaque ligne (C4) |
| S3-08 | `tests/CroustyClickCollect.Tests/PanierServiceTests.cs` | Activer les tests du panier |

### Livrables

- Version 1, étiquetée v1.0.
- README avec des captures d'écran.
- Diagramme de classes ; premiers tests du cahier de recette.
- Notes de reprise de chaque membre.

### Critères de validation

- [ ] Restaurant République, 2 crousty classiques (2 sauces différentes) et 1 soda : 3 lignes, total 20,50 €. Soda retiré : 18,00 €.
- [ ] Le 11e article est refusé avec un message.
- [ ] Les 8 tests du panier sont verts.
- [ ] Chaque membre a rempli sa note de reprise.

## Sprint 4 · Reprise et commande

**Niveau de guidage :** Guidé  
**Dates :** Du lundi 18 janvier au vendredi 5 février 2027 (veille des vacances d'hiver)  
**Séances :** mercredi 20/01, 27/01, 03/02 · vendredi 22/01, 29/01, 05/02  
**Fin du sprint :** vendredi 5 février 2027, 20 h, étiquette `v1.1`

**Objectif :** Le visiteur valide sa commande : il choisit un créneau de retrait et reçoit un numéro et un code de retrait.

### Tâches

- Séance de reprise : relire sa note de reprise, relancer le projet, revue de la version 1, rétrospective, finir les TODO en retard.
- Faire les TODO S4-01 et S4-02 : créneaux de retrait (RG3), code de retrait (RG8).
- Faire les TODO S4-03 et S4-04 : prix relus dans la base (RG5), enregistrement de la commande.
- Faire les TODO S4-05 et S4-06 : vérification du formulaire par le serveur, tests de la commande.
- Conception : diagramme des cas d'utilisation du client.
- Accompagnement en séance : Séance de reprise et rattrapage ; l'ajout de données en SQL (INSERT) ; pourquoi le serveur revérifie tout.
- Pour aller plus loin (facultatif) : C8 : annulation de la commande par le client.

| TODO | Fichier | À faire |
|---|---|---|
| S4-01 | `src/CroustyClickCollect/Services/CreneauService.cs` | Calculer la liste des créneaux de retrait (RG3) |
| S4-02 | `src/CroustyClickCollect/Services/CommandeService.cs` | Fabriquer le code de retrait (RG8) |
| S4-03 | `src/CroustyClickCollect/Services/CommandeService.cs` | Recalculer les prix côté serveur (RG5) |
| S4-04 | `src/CroustyClickCollect/Data/CommandeRepository.cs` | Enregistrer la commande et ses lignes dans la base |
| S4-05 | `src/CroustyClickCollect/Controllers/CommandeController.cs` | Vérifier ce que le formulaire a envoyé (SEC4) |
| S4-06 | `tests/CroustyClickCollect.Tests/CommandeTests.cs` | Activer les tests de la commande |

### Livrables

- Version v1.1.
- Diagramme des cas d'utilisation du client.
- Cahier de recette complété (commande).
- Comptes rendus et rétrospective.

### Critères de validation

- [ ] Les 8 tests de la commande sont verts (par exemple : à 12 h 07, le premier créneau est 12 h 30).
- [ ] Une commande validée apparaît dans phpMyAdmin, avec ses lignes et un code à 4 chiffres.
- [ ] Prénom vide ou créneau inventé : message d'erreur, aucune commande enregistrée.
- [ ] Si le prix d'un produit change dans la base, la commande prend le nouveau prix.

## Sprint 5 · L'écran cuisine

**Niveau de guidage :** Guidé  
**Dates :** Du lundi 22 février au vendredi 12 mars 2027  
**Séances :** mercredi 24/02, 03/03, 10/03 · vendredi 26/02, 05/03, 12/03  
**Fin du sprint :** vendredi 12 mars 2027, 20 h, étiquette `v1.2`

**Objectif :** L'équipier se connecte, voit les commandes du jour de son restaurant et les fait avancer jusqu'au retrait.

### Tâches

- Faire les TODO S5-01 et S5-02 : retrouver le membre du personnel, vérifier son mot de passe.
- Faire les TODO S5-03 et S5-04 : commandes du jour du restaurant de la personne connectée.
- Faire les TODO S5-05 à S5-07 : faire avancer l'état d'une commande (RG6), seulement dans son restaurant (RG10).
- Faire le TODO S5-08 : tests des états.
- Conception : diagramme des cas d'utilisation du personnel.
- Accompagnement en séance : Atelier sécurité : mots de passe hachés, cookie de connexion, contrôle des accès.
- Pour aller plus loin (facultatif) : K5 : retrouver une commande par son code · G1 : déclarer un produit en rupture.

| TODO | Fichier | À faire |
|---|---|---|
| S5-01 | `src/CroustyClickCollect/Data/PersonnelRepository.cs` | Retrouver un membre du personnel par son identifiant |
| S5-02 | `src/CroustyClickCollect/Controllers/CompteController.cs` | Vérifier le mot de passe (SEC2) |
| S5-03 | `src/CroustyClickCollect/Data/CommandeRepository.cs` | Lire les commandes du jour d'un restaurant (écran cuisine) |
| S5-04 | `src/CroustyClickCollect/Controllers/CuisineController.cs` | Lire le restaurant de la personne connectée (RG10) |
| S5-05 | `src/CroustyClickCollect/Services/EtatCommandeService.cs` | Donner l'état suivant d'une commande (RG6) |
| S5-06 | `src/CroustyClickCollect/Data/CommandeRepository.cs` | Enregistrer le nouvel état d'une commande |
| S5-07 | `src/CroustyClickCollect/Controllers/CuisineController.cs` | Faire avancer l'état d'une commande (K3, RG6, RG10) |
| S5-08 | `tests/CroustyClickCollect.Tests/EtatCommandeServiceTests.cs` | Activer les tests du cycle de vie d'une commande |

### Livrables

- Version v1.2.
- Diagramme des cas d'utilisation du personnel.
- Cahier de recette complété, dont les tests de sécurité.
- Comptes rendus et rétrospective.

### Critères de validation

- [ ] Connexion avec equipier.republique ; un mauvais mot de passe affiche « Identifiant ou mot de passe incorrect ».
- [ ] L'adresse /Cuisine, sans être connecté, renvoie vers la page de connexion.
- [ ] Un équipier d'Esplanade ne voit pas, et ne peut pas faire avancer, une commande de République.
- [ ] Une commande passe de Reçue à Retirée, dans l'ordre ; les tests des états sont verts.

## Sprint 6 · Suivi en direct et mise en ligne

**Niveau de guidage :** Autonomie partielle  
**Dates :** Du lundi 15 au vendredi 26 mars 2027  
**Séances :** mercredi 17/03, 24/03 · vendredi 19/03, 26/03  
**Fin du sprint :** vendredi 26 mars 2027, 20 h, étiquette `v1.3`

**Objectif :** Le client suit sa commande sans recharger la page, et le site est accessible en ligne.

### Tâches

- Faire les TODO S6-01 à S6-03 : état de la commande en JSON, page de suivi actualisée en JavaScript.
- Sans TODO : l'écran cuisine se met à jour tout seul (K4). À vous de trouver où et comment.
- Mettre le site en ligne sur le serveur, avec la procédure fournie ; le mot de passe de la base est défini sur le serveur, jamais dans le dépôt.
- Documentation technique : écrire la procédure de mise en ligne suivie par l'équipe.
- Accompagnement en séance : Atelier JavaScript (fetch et JSON) de 45 minutes en début de sprint ; mise en ligne guidée par l'enseignant.
- Pour aller plus loin (facultatif) : K6 : annulation en cuisine avec un motif · G3 : tableau de bord du gérant.

| TODO | Fichier | À faire |
|---|---|---|
| S6-01 | `src/CroustyClickCollect/Data/CommandeRepository.cs` | Lire l'état d'une commande, seulement si le code est bon |
| S6-02 | `src/CroustyClickCollect/Controllers/CommandeController.cs` | Renvoyer l'état de la commande au format JSON (C7) |
| S6-03 | `src/CroustyClickCollect/wwwroot/js/suivi.js` | Demander l'état au serveur et l'afficher |

### Livrables

- Version v1.3.
- Site en ligne, adresse indiquée dans le README.
- Procédure de mise en ligne dans docs.
- Comptes rendus et rétrospective.

### Critères de validation

- [ ] La page de suivi passe de « Reçue » à « Prête » sans rechargement quand l'équipier fait avancer la commande.
- [ ] /Commande/Etat avec un mauvais code renvoie une erreur 404.
- [ ] Le site en ligne s'ouvre en HTTPS et le test de référence y fonctionne.
- [ ] Aucun vrai mot de passe dans le dépôt GitHub.

## Sprint 7 · Finaliser et présenter

**Niveau de guidage :** Autonome  
**Dates :** Du lundi 29 mars au vendredi 2 avril 2027 (veille des vacances de printemps)  
**Séances :** mercredi 31/03 · vendredi 02/04  
**Fin du sprint :** vendredi 2 avril 2027, 20 h, étiquette `v2.0`

**Objectif :** Chaque équipe livre un projet présentable dans un portfolio, et chaque membre sait expliquer tout le code.

### Tâches

- Faire les TODO S7-01 et S7-02 : allergènes sur la carte, retrait du bloc de vérification de l'accueil.
- Rejouer tout le cahier de recette sur le site en ligne et corriger les régressions.
- README final : présentation, captures, adresse du site, technologies, membres.
- Manuel utilisateur court (client et équipier) ; vidéo de démonstration de 2 à 3 minutes.
- Fiche individuelle (préparation E4 et E5) ; démonstration finale en séance.
- Accompagnement en séance : Préparation des épreuves E4 et E5 : présenter son projet, expliquer le code d'un autre.

| TODO | Fichier | À faire |
|---|---|---|
| S7-01 | `src/CroustyClickCollect/Views/Carte/Index.cshtml` | Afficher les allergènes de chaque produit (V5) |
| S7-02 | `src/CroustyClickCollect/Views/Home/Index.cshtml` | Retirer ce bloc de vérification avant la démonstration finale |

### Livrables

- Version finale, étiquetée v2.0.
- README final, manuel utilisateur, vidéo.
- Cahier de recette complet.
- Fiches individuelles.

### Critères de validation

- [ ] Le test de référence passe entièrement sur le site en ligne.
- [ ] Le README permet à quelqu'un d'extérieur de comprendre et d'installer le projet.
- [ ] Pendant la démonstration, chaque membre explique une partie qu'il n'a pas codée.
- [ ] Plus aucun TODO dans le code, sauf ceux des fonctions bonus non choisies.
