TrelloPowerUp.initialize({
    'board-button': function (t, options) {
        return [{
            text: 'Storyboard',
            callback: callback()
        }];
    },
});

function callback() {
    console.log("OK");
}