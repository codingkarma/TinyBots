function ConnectAndWireEvents() {
    var player = new Robot(1, '', 10, 10, 50, 9);
    var enemy = new Robot(2, 'enemy', 10, 10, 50, 7);
    var game = new Game([player, enemy]);

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
            player.hitpoints -= attacker.damage;
            $('#player1 > .player-name').text(attacker.name + ' HP:' + player.hitpoints);
        }
        else {
            enemy.hitpoints -= attacker.damage;
            $('#player2 > .player-name').text('ENEMY ROBOT HP:' + enemy.hitpoints);
        }
    };

    botProxy.client.onConnect = function () {
        player.name = prompt('Enter your name:', '');
        $('#player1 > .player-name').text(player.name);
        botProxy.server.join(player);
    };

    botProxy.client.enablePlay = function () {
        $('#attack').prop('disabled', false);
        $('#attack2').prop('disabled', false);
    };

    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            botProxy.server.sendMessage(player.name, $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });

        $('#attack').click(function () {
            // Call the Send method on the hub.
            botProxy.server.attack(player, enemy);
        });

        $('#attack2').click(function () {
            // Call the Send method on the hub.
            botProxy.server.attack(enemy, player);
        });
    });
}