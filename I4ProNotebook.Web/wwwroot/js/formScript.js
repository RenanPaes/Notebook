var vmRegister = new Vue({
    el: "#formContainer",
    data: {
        name: undefined,
        phoneNumbers: [],
        emails: [],
        inputPhoneNumber: undefined,
        inputEmail: undefined,
        removeEmails: [],
        removePhoneNumbers: []
    },
    mounted: function () {
        if (obj) {
            this.name = obj.name;
            this.emails = obj.emails;
            this.phoneNumbers = obj.phoneNumbers;
        }
    },
    methods: {
        addPhoneNumber: function () {
            if (this.inputPhoneNumber) {
                this.phoneNumbers.push({ number: this.inputPhoneNumber });
                this.inputPhoneNumber = undefined;
            }
        },

        addEmails: function () {
            if (this.inputEmail) {
                this.emails.push({ emailName: this.inputEmail });
                this.inputEmail = undefined;
            }
        },

        deletePhoneNumber: function (index, id) {
            this.phoneNumbers.splice(index, 1);
            this.removePhoneNumbers.push(id);
        },

        deleteEmails: function (index, id) {
            this.emails.splice(index, 1);
            this.removeEmails.push(id);
        },

        saveContact: function () {
            var _this = this;

            $.ajax({
                url: urlPost,
                method: "POST",
                data: {
                    "Name": _this.name,
                    "PhoneNumbers": _this.phoneNumbers,
                    "Emails": _this.emails,
                    "EmailRemoveIds": _this.removeEmails,
                    "PhoneNumberRemoveIds": _this.removePhoneNumbers
                },
                error: function (data) {
                    if (data.status == 400)
                        alert("Ocorreu um erro", data.responseJSON);
                    else if (data.status == 500)
                        alert("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
                success: function (data) {
                    window.location.href = urlIndex;
                }
            });
        }
    }
});