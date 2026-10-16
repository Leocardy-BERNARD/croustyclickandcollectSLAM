-- =====================================================================
--  Crousty Click & Collect : compte MySQL utilisé par le site
--  Script n°3, à exécuter en TROISIÈME (en tant que root).
--
--  BONNE PRATIQUE (bloc 3, SEC7) : le site ne se connecte JAMAIS avec « root ».
--  Il utilise ce compte, qui peut seulement lire, ajouter et modifier des
--  lignes dans la base « crousty ». Il ne peut ni supprimer une table, ni
--  toucher aux autres bases. Si le site est piraté, les dégâts sont limités.
--
--  Ce mot de passe sert UNIQUEMENT sur votre poste, pour le développement.
--  C'est le même que dans .env.example. Sur le serveur en ligne, l'enseignant
--  utilise un autre mot de passe, qui n'est écrit nulle part dans le dépôt.
-- =====================================================================

-- Le compte est créé deux fois, car « localhost » et « 127.0.0.1 » sont deux
-- façons de dire « cet ordinateur » : selon sa configuration, MySQL voit l'une
-- ou l'autre. Les deux comptes ont le même mot de passe et les mêmes droits.
CREATE USER IF NOT EXISTS 'crousty_app'@'localhost' IDENTIFIED BY 'crousty_dev_2026';
CREATE USER IF NOT EXISTS 'crousty_app'@'127.0.0.1' IDENTIFIED BY 'crousty_dev_2026';

-- SELECT = lire, INSERT = ajouter, UPDATE = modifier. Rien de plus.
-- (Une fonction bonus a besoin de DELETE ? Ajoutez-le ici, en équipe, et notez pourquoi.)
GRANT SELECT, INSERT, UPDATE ON crousty.* TO 'crousty_app'@'localhost';
GRANT SELECT, INSERT, UPDATE ON crousty.* TO 'crousty_app'@'127.0.0.1';

FLUSH PRIVILEGES;
