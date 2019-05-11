$(document).ready(function () {
    setupEvents();
    alert("s");
    function setupEvents() {

        var imgURL = '~/img/';
        window.emojiPicker = new EmojiPicker({
            emojiable_selector: '#cmt-cb-w',
            assetsPath: imgURL,
            popupButtonClasses: 'material-icons pu-emj'
        });
        window.emojiPicker.discover();
        $('.emoji-menu').css({ top: (top - 360) + 'px' });

    }

});