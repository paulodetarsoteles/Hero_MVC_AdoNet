//Edição da relação filme/heróis
$(document).ready(function () {
    $("#btnAddHero").click(function () {
        var chkRptHero = false;
        var currentValue = $("#HeroId option:selected").text().trim();

        if (currentValue == "Selecione...") {
            return false;
        }

        $('#listHeroes li').each(function () {
            var current = $(this).text().trim();

            if (current == $("#HeroId option:selected").text().trim()) {
                chkRptHero = true;
            }
        });

        if (!chkRptHero) {
            $("#listHeroes").append(
                "<li>" +
                $("#HeroId option:selected").text() +
                "<input type='hidden' name='chkHero' id='chkHero' class='chkHero' value='" + $("#HeroId option:selected").val() + "'>" +
                "</li>");
        } else {
            alert("Herói já adicionado!");
        }
    });

    $('#listHeroes').on('click', "li", function () {
        $(this).remove();
        return false;
    });
});