$(document).ready(function (){
        $(".address").suggestions({
            token: "31b267c0cf2b956ecce956b8ed6e6c918dd1c5c3",
            type: "ADDRESS",
            /* Вызывается, когда пользователь выбирает одну из подсказок */
            onSelect: function (suggestion)
            {
                console.log(suggestion);
            }
        });
});
