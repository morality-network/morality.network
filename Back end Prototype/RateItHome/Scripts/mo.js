$(function () {

    var abiRaw = '[{"constant":true,"inputs":[],"name":"name","outputs":[{"name":"","type":"string"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"_spender","type":"address"},{"name":"_value","type":"uint256"}],"name":"approve","outputs":[{"name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"name":"token","type":"address"}],"name":"recoverTokens","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"totalSupply","outputs":[{"name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"_from","type":"address"},{"name":"_to","type":"address"},{"name":"_value","type":"uint256"}],"name":"transferFrom","outputs":[{"name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"decimals","outputs":[{"name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"burnAmount","type":"uint256"}],"name":"burn","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"name":"value","type":"uint256"}],"name":"upgrade","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"name":"_name","type":"string"},{"name":"_symbol","type":"string"}],"name":"setTokenInformation","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"upgradeAgent","outputs":[{"name":"","type":"address"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"upgradeMaster","outputs":[{"name":"","type":"address"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[{"name":"_owner","type":"address"}],"name":"balanceOf","outputs":[{"name":"balance","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"getUpgradeState","outputs":[{"name":"","type":"uint8"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"owner","outputs":[{"name":"","type":"address"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"symbol","outputs":[{"name":"","type":"string"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"canUpgrade","outputs":[{"name":"","type":"bool"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"_to","type":"address"},{"name":"_value","type":"uint256"}],"name":"transfer","outputs":[{"name":"success","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"name":"token","type":"address"}],"name":"tokensToBeReturned","outputs":[{"name":"","type":"uint256"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"totalUpgraded","outputs":[{"name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"agent","type":"address"}],"name":"setUpgradeAgent","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[{"name":"_owner","type":"address"},{"name":"_spender","type":"address"}],"name":"allowance","outputs":[{"name":"remaining","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"isToken","outputs":[{"name":"weAre","type":"bool"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"newOwner","type":"address"}],"name":"transferOwnership","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"BURN_ADDRESS","outputs":[{"name":"","type":"address"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"name":"master","type":"address"}],"name":"setUpgradeMaster","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"inputs":[],"payable":false,"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":false,"name":"newName","type":"string"},{"indexed":false,"name":"newSymbol","type":"string"}],"name":"UpdatedTokenInformation","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"name":"_from","type":"address"},{"indexed":true,"name":"_to","type":"address"},{"indexed":false,"name":"_value","type":"uint256"}],"name":"Upgrade","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"name":"agent","type":"address"}],"name":"UpgradeAgentSet","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"name":"burner","type":"address"},{"indexed":false,"name":"burnedAmount","type":"uint256"}],"name":"Burned","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"name":"owner","type":"address"},{"indexed":true,"name":"spender","type":"address"},{"indexed":false,"name":"value","type":"uint256"}],"name":"Approval","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"name":"from","type":"address"},{"indexed":true,"name":"to","type":"address"},{"indexed":false,"name":"value","type":"uint256"}],"name":"Transfer","type":"event"}]';
    var abi = JSON.parse(abiRaw);
    var contractAddress = "0x97e8dbc4bab20a825edc72df441bde3102508605";
    var address = web3.eth.accounts[0];
    var gasEstimate;

    function init() {
        address = web3.eth.accounts[0];
        if (web3 && address) {

            var MyContract = web3.eth.contract(abi).at(contractAddress);
            MyContract.balanceOf(address, function (sc, er) {
                $("#balance-ph").html(er.toString());
                $("#balance-ph").attr("title", er.toString());
                $("#marker").attr("desc", address);
            });
        }
        else {
            alert('You should install meta mask or login bro');
        }
    }

    init();

    function estimateTransfer(to, amount) {
        if (web3) {
            var contract = web3.eth.contract(abi).at(contractAddress);
            contract.transfer.estimateGas(to, amount, { from: address }, function (error, result) {
                if (!error)
                    console.log(result)
                else
                    console.error(error);
            });
        }
    }

    function transferMo(to, amount, gas) {
        if (web3) {
            MyContract.transfer(to, amount, {
                from: address,
                gas: gas
            }, function (error, result) {
                if (!error)
                    console.log(result)
                else
                    console.error(error);
            });
        }
    }

    function transferMoCredit(to, amount) {
        $.ajax({
            url: '../Transaction/TransferMoCredit',
            type: 'POST',
            data: jQuery.param({ to: to, amount: amount }),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (response) {
                alert(response.status);
            },
            error: function () {
                alert("error");
            }
        });
    }

    //action must take a parameter result (transaction json)
    function getAllMoTransactions(fromAddress, action, debug) {
        if (web3) {
            var filter = web3.eth.filter({ fromBlock: 1, toBlock: 'latest', address: "0x97e8dbc4bab20a825edc72df441bde3102508605", from: fromAddress });
            filter.get(function (error, result) {
                if (!error) {
                    if (debug && debug === true) {
                        console.log(JSON.stringify(result, null, 2)); console.log(result.length);
                        for (var i = 0; i < result.length; i++) {
                            console.log("Data: " + parseInt(result[i].data, 16));
                            for (var j = 0; j < result[i].topics.length; j++) {
                                console.log("Topics: " + result[i].topics[j]);
                            }
                        }
                    }
                    if(action){
                        action(result);
                    }
                }
            });
        }
    }

   
});