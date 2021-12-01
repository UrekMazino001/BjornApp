using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BjornApp.Models
{
    public class Constantes
    {
        public static FirebaseClient firebase = new FirebaseClient("https://xamarinbjorn-default-rtdb.firebaseio.com/");
        public const string WebApiFirebase = "AIzaSyCoVUX1i53nrywXV9nAdv1gitU6xK2irMY";
        public const string StorageUrl = "xamarinbjorn.appspot.com";
    }
}
