// Ебал рот того, кто это читает, чтоб у тебя мать сдохла нахуй

mergeInto(LibraryManager.library, {

  GetDataPlayer: function () {
    myGameInstance.SendMessage('Fade', 'GetData', player.getName());
    myGameInstance.SendMessage('Fade', 'SetPhoto', player.getPhoto('medium'));
  },

  });