mergeInto(LibraryManager.library, {
LoadPlayer: function () {
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetName', player.getName());
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetPhoto', player.getPhoto('medium'));
  },

  AuthPlayer: function () {
    auth();
  },
  });