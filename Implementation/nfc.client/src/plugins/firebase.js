import firebase from 'firebase';

// reqired for side-effects
require("firebase/firestore");

const config = {
    apiKey: "AIzaSyDfLO47zzdk3Ayz_X3kJhTIdH-p-CB0AEo",
    authDomain: "fish-d3e4f.firebaseapp.com",
    databaseURL: "https://fish-d3e4f.firebaseio.com",
    projectId: "fish-d3e4f",
    storageBucket: "fish-d3e4f.appspot.com",
    messagingSenderId: "153756661190",
    appId: "1:153756661190:web:b3549b23e17840619feec7",
    measurementId: "G-YJ2X3Z2TST"
  };

  firebase.initializeApp(config);

  // initialize cloud firestore through firebase
  let instance = firebase.firestore();
  instance.settings({
      timestampsInSnapshots: true
  });

  export default instance;