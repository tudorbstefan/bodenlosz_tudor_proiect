"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var t = 0;
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g,
        "&gt;");
    var strong = document.createElement("strong");
    strong.textContent = user + ": ";
    var span = document.createElement("span");
    var encodedMsg = msg;
    span.textContent = encodedMsg;
    var div = document.createElement("div");
    if (t === 0) {
        div.className = "msg_cotainer";
        t = 1;
    } else {
        div.className = "msg_cotainer_send";
        t = 0;
    }
    div.appendChild(strong);
    div.appendChild(span);
    document.getElementById("messagesList").appendChild(div);
});
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", "", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
