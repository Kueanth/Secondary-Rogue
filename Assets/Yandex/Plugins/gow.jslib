mergeInto(LibraryManager.library, {
  LoadPlayer: function () {
    if(meow){
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetName', player.getName());
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetPhoto', player.getPhoto('large'));
    }
  },

  AuthPlayer: function () {
    auth();
  },

  buyItem: function(id) {
    window.ysdk.getPayments(id);
  },

  checkedItem: function(){
    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '01')) {
          myGameInstance.SendMessage('Initialization Pets', 'Checked01', 1);
        }
    }).catch(err => {
        // Выбрасывает исключение USER_NOT_AUTHORIZED для неавторизованных пользователей.
    });

    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '01')) {
          myGameInstance.SendMessage('Initialization Pets', 'Checked01', 1);
        }
    }).catch(err => {
        // Выбрасывает исключение USER_NOT_AUTHORIZED для неавторизованных пользователей.
    });
  },

  checkedItemConsume: function(){
    payments.getPurchases().then(purchases => purchases.forEach(consumePurchase));
  },

  OpenGame: function() {
    if(meow){
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetName', player.getName());
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetPhoto', player.getPhoto('large'));
    }
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
                console.log(reason);
            }
        })
  },

    SetDataInLeaderboards: function (value) {
      ysdk.getLeaderboards()
     .then(lb => {
     lb.setLeaderboardScore('levels', value);
     });
    },

    IsPlayerAuth: function () {
        window.ysdk.getPlayer().then(_player => {
            var result;
            if (_player.getMode() === 'lite') {
                myGameInstance.SendMessage("Initialization Yandex SDK", "LoadAuthBar", result);
            }
        });
    },

    AskSetLeaderboardScore: function (rawNameStr) {
        var lbname = UTF8ToString(rawNameStr);
        window.ysdk.getLeaderboards()
            .then(lb => lb.getLeaderboardPlayerEntry(lbname))
            .then(res => {
                var json = {
                    "publicName": res.player.publicName,
                    "rank": res.rank,
                    "score": res.score
                };

                myGameInstance.SendMessage("Initialization Yandex SDK", "Meow", JSON.stringify(json));
            })
            .catch(err => {
                if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
                    
                }
            });
    },

    GetDataInLeaderboards: function (rawNameStr, includeUser, quantityAround, quantityTop) {
        var lbname = UTF8ToString(rawNameStr);
        ysdk.getLeaderboards()
            .then(lb => {
                lb.getLeaderboardEntries(lbname, { quantityTop: quantityTop, includeUser: includeUser, quantityAround: quantityAround })
                    .then(res => {
                        var lbAnswer = {
                            "entries": []
                        };
                        var lbEntries = [];
                        res.entries.forEach(line => {
                            var entry = {
                                "publicName": line.player.publicName,
                                "rank": line.rank,
                                "imageURL": line.player.getAvatarSrc('large'),
                                "score": line.score
                            };
                            lbEntries.push(entry);
                        });
                        lbAnswer.entries = lbEntries;
                        myGameInstance.SendMessage("Initialization Yandex SDK", "Gow", JSON.stringify(lbAnswer));
                    });
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

    ShowAdWithRewardPet : function() {
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage('Progress', 'addPointPet');
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
    },

    LoadData : function() {
        player.getData().then(_date => {
          const myJSON = JSON.stringify(_date);
          myGameInstance.SendMessage('Progress', 'Load', myJSON);
          myGameInstance.SendMessage('Initialization Pets', 'InitializationPets');
        });
    },
  });