$(document).ready(function () {

    var modal;

    function createModal(body, title) {
        modal = new SimpleModal({
            title: title,
            body: '<p>'+body+'</p>',
            buttons: [
                {
                    value: 'Cancel'
                },
                {
                    value: 'OK',
                    callback: function (modal) {
                        modal.updateTitle('You clicked OK!');
                        return false;
                    }
                }]
        });
     }

    function showModal() {
        if (modal) {
            modal.show();
        }
    }

});

/*
https://www.cssscript.com/customizable-modal-dialog-javascript-library-simple-modal-js/
<link href="src/simple-modal.css" rel="stylesheet">
<script src="src/simple-modal.js"></script>
*/