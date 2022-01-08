(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular
        .module('csbc')
        .factory(serviceId, ['common', datacontext]);

    function datacontext(common) {

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');

        var primePromise;
        var $q = common.$q;

        var EntityNames = {
            person: 'Person',
            color: 'Color',
            division: 'Division',
            season: 'Season'
        }
        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            getWebContent: getWebContent,
            getWebContentDetail: getWebContentDetail
        };

        return service;

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];
            return $q.when(people);
        }
        function getWebContent() {
            var content = [
                { id: 1, contentScreen: 'Main', contentSequence: '1', title: 'Title  1', subtitle: '', location: '', dateAndTime: '', body: 'I have a guppy', page: 'Main', expirationDate: '06/30/2015' },
                { id: 2, contentScreen: 'Main', contentSequence: '1', title: 'Title  2', subtitle: 'sub2', location: '', dateAndTime: '', body: 'This is a message', page: 'Main', expirationDate: '06/30/2015' },
            { id: 3, contentScreen: 'Main', contentSequence: '1', title: 'Title  3', subtitle: 'Something else', location: '', dateAndTime: '', body: 'I have 3 little fishies', page: 'Main', expirationDate: '06/30/2015' },
        { id: 4, contentScreen: 'Main', contentSequence: '1', title: 'Title  4', subtitle: 'sub2', location: '', dateAndTime: '', body: 'This is a body thingy', page: 'Main', expirationDate: '06/30/2015' }

            ];
            return $q.when(content);
        }

        function getWebContentDetail(id) {
            var content = getWebContent();
            var cone = _.find(content, function (id) { return })
            return
        }

        function querySucceeded(data) {
            registrations = data.results;
            log('Retrieved [Registration Partials] from remote datasource', registrations.length, true);
            return registrations;
        }

    }


})();