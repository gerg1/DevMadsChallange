TrelloPowerUp.initialize({
    'board-buttons': function (t, options) {
        return [{
            text: 'StoryBoard',
            callback: function (t) {
                return t.modal({
                    url: 'index.html',
                    fullscreen: true, // Whether the modal should stretch to take up the whole screen
                });
            }
        }];
    }
});