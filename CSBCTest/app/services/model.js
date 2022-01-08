(function () {
    'use strict';

    // Factory name is handy for logging
    var serviceId = 'model';

    // Define the factory on the module.
    // Inject the dependencies. 
    // Point to the factory definition function.
    angular.module('app').factory(serviceId, model);

    function model() {
        // Define the functions and properties to reveal.
        var service = {
            configureMetadataStore: configureMetadataStore
        };

        return service;

        function configureMetadataStore(metadataStore) {
            registerPerson(metadataStore);
            registerRegistration(metadataStore);
            //registerTimeSlot(metadataStore);
        }

        //#region Internal Methods        

        function registerPerson(metadataStore) {
            metadataStore.registerEntityTypeCtor('Person', Person);

            function Person() { }

            Object.defineProperty(Person.prototype, 'fullName', {
                get: function () {
                    var fn = this.firstName;
                    var ln = this.lastName;
                    return ln ? fn + ' ' + ln : fn;
                }
            });

        }


        function registerRegistrations(metadataStore) {
            metadataStore.registerEntityTypeCtor('Players', Registration);

            function Registration() { }

            Object.defineProperty(Registration.prototype, 'tagsFormatted', {
                get: function () {
                    return this.tags ? this.tags.replace(/\|/g, ', ') : this.tags;
                },
                set: function (value) {
                    this.tags = value.replace(/\, /g, '|');
                }
            });
        }



        //#endregion
    }
})();