mergeInto(LibraryManager.library, {
  LoadPlayer: function () {
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetName', player.getName());
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetPhoto', player.getPhoto('large'));
  },

  AuthPlayer: function () {
    auth();
  },

  RateGame: function() {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },

    SetDataInLeaderboards: function (value) {
      ysdk.getLeaderboards()
     .then(lb => {
     lb.setLeaderboardScore('levels', value);
     });
    },

  ShowAdWithReward : function() {
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage('Initialization - Entity Component System', 'resurrectionPlayer');
        },
        onClose: () => {
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }   
    }
})
  },

    SaveData : function(date) {
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        player.setData(myobj);
        console.log("SaveData");
    },

    LoadData : function() {
        player.getData().then(_date => {
          const myJSON = JSON.stringify(_date);
          myGameInstance.SendMessage('Progress', 'Load', myJSON);
        });
    },
  });