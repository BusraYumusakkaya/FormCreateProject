$(document).ready(function () {
    $("#myButton").click(function () {
        $("#myModal").modal("show");
        var myUrl = "/Form/GetQuestions";
        $.ajax({
            url: myUrl,
            type: "GET",
            success: function (response) {
                var form = $("#myModal .modal-body form");
                var row = $("<div>", { class: "row" });
                var col1 = $("<div>", { class: "col-md-6" });
                var col2 = $("<div>", { class: "col-md-6" });
                row.append(col1, col2);
                form.prepend(row);

                $.each(response, function (index, question) {
                    var checkbox = $("<input>", { type: "checkbox", name: "ids", value: question.id, checked: false });
                    var cardHeader = $("<p>", { class: "card-header", id: question.name }).text(question.name);
                    var card = $("<div>", { class: "card" }).append(cardHeader);
                    var formCheck = $("<div>", { class: "form-check" }).append(checkbox, card);

                    
                    if (index % 2 === 0) {
                        col1.append(formCheck);
                    } else {
                        col2.append(formCheck);
                    }
                    if (question.name === "E-posta") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "email" }).text("E-posta adresini giriniz:");
                                var input = $("<input>", { type: "email", class: "form-control", id: "email", placeholder: "a.a@hotmail.com" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #email").prev("label").remove();
                                $("#myModal .modal-body form #email").remove();
                            }
                        });
                    }

                    if (question.name === "Ad") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "name" }).text("Adınız:");
                                var input = $("<input>", { type: "text", class: "form-control", id: "name", placeholder: "Örn.Busra" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #name").prev("label").remove();
                                $("#myModal .modal-body form #name").remove();
                            }
                        });
                    }

                    if (question.name === "Soyad") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "surname" }).text("Soyadınız:");
                                var input = $("<input>", { type: "text", class: "form-control", id: "surname", placeholder: "Örn.Sarı" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #surname").prev("label").remove();
                                $("#myModal .modal-body form #surname").remove();
                            }
                        });
                    }

                    if (question.name === "Yaş") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "age" }).text("Yaşınız:");
                                var input = $("<input>", { type: "number", class: "form-control", id: "age", placeholder: "Örn.26" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #age").prev("label").remove();
                                $("#myModal .modal-body form #age").remove();
                            }
                        });
                    }

                    if (question.name === "Doğum Tarihi") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "birthday" }).text("Doğum Tarihiniz:");
                                var input = $("<input>", { type: "date", class: "form-control", id: "birthday", placeholder: "02/04/1997" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #birthday").prev("label").remove();
                                $("#myModal .modal-body form #birthday").remove();
                            }
                        });
                    }

                    if (question.name === "Telefon") {
                        checkbox.on("change", function () {
                            if (this.checked) {
                                var label = $("<label>", { for: "phone" }).text("Telefon Numaranız:");
                                var input = $("<input>", { type: "tel", class: "form-control", id: "phone", placeholder: "Örn.05554443322" });
                                $("#myModal .modal-body form").append(label, input);
                            } else {
                                $("#myModal .modal-body form #phone").prev("label").remove();
                                $("#myModal .modal-body form #phone").remove();
                            }
                        });
                    }
                });
                
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
            }
        });
    });
    if (window.location == 'https://localhost:7176/Form') {
        GetForms();
    }
   
});

function GetForms() {
    $.ajax({
        type: "GET",
        url: "/Form/GetForms",
        dataType: "json",
        success: function (data) {
            var table = "<table class='table'><thead><tr><th>Form Adı</th><th>Form İçeriği</th><th>Oluşturma Tarihi</th><th> </th></tr></thead><tbody>";
            $.each(data, function (index, value) {
                table += "<tr><td>" + value.name + "</td><td>" + value.description + "</td><td>" + value.createAt + "</td><td><button class='btn btn-success' onclick='GoToForm(\"" + value.id + "\")'>Forma Git</button></td></tr>";
            });
            table += "</tbody></table>";
            $("#formList").append(table);

            $("#searchBtn").click(function () {
                var searchValue = $("#searchInput").val();
                var filteredData = data.filter(function (item) {
                    return item.name.toLowerCase().includes(searchValue.toLowerCase());
                });
                $("#formList").empty();
                var table = "<table class='table'><thead><tr><th>Form Adı</th><th>Form İçeriği</th><th>Oluşturma Tarihi</th><th> </th></tr></thead><tbody>";
                $.each(filteredData, function (index, value) {
                    table += "<tr><td>" + value.name + "</td><td>" + value.description + "</td><td>" + value.createAt + "</td><td><button class='btn btn-success' onclick='GoToForm(\"" + value.id + "\")'>Forma Git</button></td></tr>";
                });
                table += "</tbody></table>";
                $("#formList").append(table);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Hata: " + textStatus + " - " + errorThrown);
        }
    });
}
function GoToFormList() {
    window.location.href = 'https://localhost:7176/Form';
}

function GoToForm(formId) {
    window.location.href = "/Form/GetToForm/" + formId;
    
}
function CancelSpending() {
    $("#confirmModalContent").html("Geri dönmek istediğinizden emin misiniz?");
    $("#confirmYes").attr("onclick", "CancelConfirm()");
    $("#confirmModal").modal("show");
    setTimeout(function () {
        GoToFormList();
    }, 2000);
}

