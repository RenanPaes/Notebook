var vmGetContacts = new Vue({
    el: "#indexContainer",
    data: {
        contacts: [],
    },
    mounted: function () {
        this.getContacts();
    },
    methods: {
        getContacts: function () {
            var _this = this;

            $.ajax({
                url: urlPost,
                method: "POST",
                data: {},
                error: function (data) {
                    if (data.status == 400)
                        alert("Ocorreu um erro", data.responseJSON);
                    else if (data.status == 500)
                        alert("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
                success: function (data) {
                    _this.contacts = data;
                }
            });
        },

        details: function (id) {
            window.location.href = urlDetails + '/' + id;
        }
    }
});