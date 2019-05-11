alert("");

  var root = document.querySelector('#chat-holder-ma').shadowRoot;

    var profile = root.querySelector('#cw-profile');
    profile.addEventListener('click', function () { openTab("cw-profile"); });
    var chat = root.querySelector('#cw-chat');
    chat.addEventListener('click', function () { openTab("cw-chat"); });
    var stats = root.querySelector('#cw-stats');
    stats.addEventListener('click', function () { openTab("cw-stats"); });

    function openTab(tabId) {
       
        var root = document.querySelector('#chat-holder-ma').shadowRoot;
        var itemSelected = root.querySelector('#' + tabId);
        var commentTab = root.querySelector('.comment-section');
        var statsTab = root.querySelector('.ri-moc-section');
        var profileTab = root.querySelector('.ri-profile-section');

        if (tabId === "cw-profile") {
            profileTab.style.display = 'block';
            commentTab.style.display = 'none';
            statsTab.style.display = 'none';
            root.querySelector('#cw-profile').classList.add("selected-tab");
            root.querySelector('#cw-chat').classList.remove("selected-tab");
            root.querySelector('#cw-stats').classList.remove("selected-tab");
        } else if (tabId === "cw-chat") {
            profileTab.style.display = 'none';
            commentTab.style.display = 'block';
            statsTab.style.display = 'none';
            root.querySelector('#cw-profile').classList.remove("selected-tab");
            root.querySelector('#cw-chat').classList.add("selected-tab");
            root.querySelector('#cw-stats').classList.remove("selected-tab");
        }
        else if (tabId === "cw-stats") {
            profileTab.style.display = 'none';
            commentTab.style.display = 'none';
            statsTab.style.display = 'block';
            root.querySelector('#cw-profile').classList.remove("selected-tab");
            root.querySelector('#cw-chat').classList.remove("selected-tab");
            root.querySelector('#cw-stats').classList.add("selected-tab");
        }
    }