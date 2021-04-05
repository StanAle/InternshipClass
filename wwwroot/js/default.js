// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#add").click(function () {
        var newcomerName = $("#newcomer").val();
        $.ajax({
            url: `/Home/AddMember?memberName=${newcomerName}`,
            success: function (data) {
                // Remember string interpolation
                $("#list").append(`<li class="member" member-id="${data}">
		            <span class="name">${newcomerName}</span><span class="delete fa fa-remove"></span><i class="startEdit fa fa-pencil" data-toggle="modal" data-target="#editClassmate"></i>
                </li>`);
                $("#newcomer").val("");
            },
            error: function (data) {
                alert(`Failed to add ${newcomerName}`);
            },
        });
    })
    $("#clear").click(function () {
        $("#newcomer").val("");
    })

    // Bind event to dynamically created element: https://makitweb.com/attach-event-to-dynamically-created-elements-with-jquery
    $("#list").on("click", ".delete", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        $.ajax({
            url: `/Home/RemoveMember/${id}`,
            type: 'DELETE',
            success: function () {
                targetMemberTag.remove();
            },
            error: function () {
                alert(`Failed to delete member with id=${id}`);
            }
        })
    })

    $("#list").on("click", ".startEdit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        var currentName = targetMemberTag.find(".name").text();
        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
    })

    $("#editClassmate").on("click", "#submit", function () {
        var name = $('#classmateName').val();
        var index = $('#editClassmate').attr("memberIndex");
        var targetMember = $('.name').eq(index);
        console.log(`/Home/UpdateMember?index=${index}&name=${name}`);
        $.ajax({
            url: `/Home/UpdateMember?index=${index}&name=${name}`,
            type: 'PUT',
            success: function () {
                targetMember.replaceWith(name);
            },
            error: function () {
                alert(`Failed to replace member ${name}`);
            }
        })
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
    function refreshWeatherForecast() {
        $.ajax({
            url: `/WeatherForecast`,
            success: function (data) {
                let tommorow = data[0];
                let tommorowDate = new Date(tommorow.date).toDateString();
                console.log(tommorow);
                $('#date').text(tommorowDate);
                $('#temperature').text(tommorow.temperatureC + ' C');
                $('#summary').text(tommorow.summary);

            },
            error: function () {
                alert(`Failed to load data`);
            }
        })
    }
    setInterval(refreshWeatherForecast, 3000);
});