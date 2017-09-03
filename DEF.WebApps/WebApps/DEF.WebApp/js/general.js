$(function () {
    console.log("Dom has been loaded");
    var digitalEngagement = {
        event: function () {
            $('ul.navbar-nav li').on("click", this.addNavActiveClass);
            $(".createRequest").on("click", function () {
                digitalEngagement.showModel('#createRequest');
            });
            $(".editExecutive").on("click", function () {
                event.preventDefault();
                digitalEngagement.showModel('#editExecutive');
            });
            $(".addAccountExcutive").on("click", function () {
                event.preventDefault();
                digitalEngagement.showModel('#addAccountExcutive');
            });
            $(".addNewAccountExcutive").on("click", this.addNewAccountExcutive);
            $(".editBtn").on("click", this.editNotes);
            $(".cancel").on("click", this.notesCancel);
            $(".updateNotes").on("click", this.updateNotes);
            $('.dropdown-menu a').on("click", this.handdleDropDown);

        },
        addNavActiveClass: function () {
            $('.navbar li.active').removeClass('active');
            console.log($(this));
            var $this = $(this);
            if (!$this.hasClass('active')) {
                $this.addClass('active');
            }
        },
        showModel: function (modalId) {
            $(modalId).modal('show');
        },
        counter: 0,
        addNewAccountExcutive: function () {
            digitalEngagement.counter++;
            $(".accountExecutiveEmail").append(
                '<div class="col-sm-11">' +
                '<div class="form-group">' +
                '<label for="firstname">AE Email Address' + digitalEngagement.counter + '</label>' +
                '<input type="email" class="form-control" id="aeemail' + digitalEngagement.counter + '">' +
                '</div>' +
                '</div>' +
                '<div class="col-sm-1">' +
                '<div class="form-group">' +
                '<label for="firstname">Lead</label>' +
                '<input type="radio" class="form-control" id="aelead" name="aelead">' +
                '</div>' +
                '</div>' +
                '<div class="clearfix"></div>');

        },
        editNotes: function () {
            event.preventDefault();
            var $noteContent = $(this).parent().parent().find(".editableContent");
            var $noteContentTextarea = $(this).parent().parent().find(".editableContent").next();
            $noteContentTextarea.val($noteContent.html());
            $noteContent.addClass('hide')
            $noteContentTextarea.removeClass('hide');
            $noteContentTextarea.next().removeClass('hide')
            $(this).hide();

        },
        notesCancel: function () {
            var $noteContent = $(this).parent().parent().find(".editableContent");
            var $noteContentTextarea = $(this).parent().parent().find(".editableContent").next();
            $noteContent.removeClass('hide')
            $noteContentTextarea.addClass('hide');
            $(this).parent().addClass("hide");
            $(this).parent().parent().find(".editBtn").show();
        },

        handdleDropDown: function () {
            event.preventDefault();
            $(this).parent().parent().parent().find('span:first-child').text($(this).text());
            $('.dropdown-menu a').removeClass('active');
            $(this).addClass('active');
        },

        updateNotes: function () {



        }

    }
    digitalEngagement.event(); /* Registering events */

});




