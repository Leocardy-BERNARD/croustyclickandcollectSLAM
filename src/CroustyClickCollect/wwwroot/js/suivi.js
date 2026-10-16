// =====================================================================
//  Suivi de commande en direct (sprint 6, user story C7).
//  Ce fichier est chargé par la page Views/Commande/Suivi.cshtml.
//  Toutes les 10 secondes, il demande au serveur l'état de la commande,
//  puis met la page à jour SANS la recharger.
// =====================================================================

// L'élément de la page qui affiche l'état. Le numéro et le code de retrait
// sont rangés dans ses attributs data-numero et data-code.
const zoneEtat = document.getElementById("etat");
const numero = zoneEtat.dataset.numero;
const code = zoneEtat.dataset.code;

// « async » : cette fonction contient des étapes qui prennent du temps
// (attendre la réponse du serveur). « await » attend la fin de l'étape.
async function actualiserEtat() {
    // TODO S6-03 (sprint 6) : demander l'état au serveur et l'afficher.
    //   Consigne : appeler l'adresse /Commande/Etat?id=…&code=… (avec numero et code),
    //              lire la réponse JSON, puis écrire la valeur « etat » dans zoneEtat.
    //   Indice   : fetch(adresse) envoie la demande ; reponse.json() lit le JSON ;
    //              zoneEtat.textContent = … change le texte affiché. Pensez à « await ».
}

// Une première fois tout de suite, puis toutes les 10 secondes (10 000 millisecondes).
actualiserEtat();
setInterval(actualiserEtat, 10000);
