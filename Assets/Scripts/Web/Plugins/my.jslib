mergeInto(LibraryManager.library, {


  SaveData: function (date) {
    var dateString = UTF8ToString(date);
    var myObj = JSON.parse(dateString);
    player.setData(myObj);
  },

  LoadData: function () {
    player.getData().then(_date =>{
        const myJSON = JSON.stringify(_date);
        myGameInstanse.SendMessage('Progress', 'SetPlayerData', myJSON);
    });
  },

  SetToLeaderboardRange: function (value) {
    if(ysdk.isAvailableMethod('leaderboards.setLeaderboardScore'))
    {
        ysdk.getLeaderboards()
        .then(lb => {
        lb.setLeaderboardScore('Range', value);
      });
    }
      
  },

  SetToLeaderboardDiamonds: function (value) {
    if(ysdk.isAvailableMethod('leaderboards.setLeaderboardScore'))
    {
        ysdk.getLeaderboards()
        .then(lb => {
        lb.setLeaderboardScore('Diamonds', value);
      });
    }
  },

  GetTopRange: function () {
    ysdk.getLeaderboards()
  .then(lb => {
    lb.getLeaderboardEntries('Range', { quantityTop: 1 })
      .then(res => myGameInstanse.SendMessage('Progress', 'SetTopRange', res));
  });
  },
  
});