function ConnectAndWireEvents() {
    var game = new Game([]);

    var botProxy = $.connection.botHub;
    botProxy.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#chat').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };

    botProxy.client.broadcastAttack = function (attacker, defender) {
        if (game.robots[0].id == defender.id) {
            game.robots[0].hitpoints -= attacker.damage;
        }
        else {
            game.robots[1].hitpoints -= attacker.damage;
        }
        $('#player1 > .player-name').text('My Hp:' + game.robots[botProxy.state.id].hitpoints);
        $('#player2 > .player-name').text('ENEMY ROBOT HP:' + game.robots[Math.abs(botProxy.state.id-1)].hitpoints);
    };

    botProxy.client.onConnect = function () {
        var name = prompt('Enter your name:', '');
        $('#player1 > .player-name').text(name);
        botProxy.server.join(new Robot(1, name, 10, 10, 50, 10));
    };
    botProxy.client.createPlayer = function (robot) {
        game.robots.push(robot);
        botProxy.state.id = robot.id - 1;
    };
    botProxy.client.enablePlay = function () {
        $('#attack').prop('disabled', false);
        $('#attack2').prop('disabled', false);
    };

    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            var player = game.robots[botProxy.state.id];
            botProxy.server.sendMessage(player.name, $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });

        $('#attack').click(function () {
            // Call the Send method on the hub.
            var player = game.robots[botProxy.state.id];
            var enemy = game.robots[Math.abs(botProxy.state.id - 1)];
            botProxy.server.attack(player, enemy);
        });
    });
}