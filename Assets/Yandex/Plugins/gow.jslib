mergeInto(LibraryManager.library, {
  LoadPlayer: function () {
    if(meow){
      Console.Log("Load Player");
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetName', player.getName());
      myGameInstance.SendMessage('Initialization Yandex SDK', 'GetPhoto', player.getPhoto('large'));
    }
  },

  GetDeviceID: function () {
        switch (window.ysdk.deviceInfo.type) {
            case "mobile": { myGameInstance.SendMessage("Progress", "Mobile"); break; }
        }
    },

  AuthPlayer: function () {
    auth();
  },

  CheckPlayer: function () {
    initPlayer();
  },

  ShowAdWithoutReward : function() {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onOpen: function(){
          myGameInstance.SendMessage('Progress', 'PauseGame');
        },
        onClose: function(wasShown) {
          myGameInstance.SendMessage('Progress', 'ResumeGame');
        },
        onError: function(error) {
          // some action on error
        }
      }
    });
      },

  buyItem01: function() {
    payments.purchase({ id: '01' }).then(purchase => {
        payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '01')) {
          myGameInstance.SendMessage('Shop', 'Checked01');
        }
    }).catch(err => {
        console.log(err);
    })
    }).catch(err => {
        console.log('Ошибка');
    })
  },

  buyItem02: function() {
    payments.purchase({ id: '02' }).then(purchase => {
        payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '02')) {
          myGameInstance.SendMessage('Shop', 'Checked02');
        }
    }).catch(err => {
        console.log(err);
    })
    }).catch(err => {
        console.log('Ошибка');
    })
  },

  checkedItem: function(){
    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '01')) {
          myGameInstance.SendMessage('Shop', 'Checked01');
        }
    }).catch(err => {
        console.log(err);
    })

    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === '02')) {
          myGameInstance.SendMessage('Shop', 'Checked02');
        }
    }).catch(err => {
        console.log(err);
    })

  },

  checkedItemConsume: function(){
    payments.getPurchases().then(purchases => purchases.forEach(consumePurchase));
  },

  OpenGame: function() {
    myGameInstance.SendMessage("Initialization Yandex SDK", "CheckedLan");

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
      myGameInstance.SendMessage("Initialization Yandex SDK", "CheckedLan");
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
          myGameInstance.SendMessage('Progress', 'PauseGame');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage('Initialization - Entity Component System', 'resurrectionPlayer');
        },
        onClose: () => {
          myGameInstance.SendMessage('Progress', 'ResumeGame');
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
          myGameInstance.SendMessage('Progress', 'PauseGame');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage('Progress', 'addPointPet');
          myGameInstance.SendMessage('Shop', 'EditText');
        },
        onClose: () => {
          myGameInstance.SendMessage('Progress', 'ResumeGame');
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
          myGameInstance.SendMessage('Initialization Pets', 'Delete');
        });
    },
  });