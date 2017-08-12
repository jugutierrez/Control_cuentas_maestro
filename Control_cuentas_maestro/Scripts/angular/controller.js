

        

            app.controller('dialogController', dialogController);

         function dialogController ($scope, $mdDialog) {
            $scope.status = '';
			$scope.items = [1,2,3,4,5];
            $scope.showAlert = function(ev) {
               $mdDialog.show(
                  $mdDialog.alert()
                     .parent(angular.element(document.querySelector('#dialogContainer')))
                     .clickOutsideToClose(true)
                     .title('TutorialsPoint.com')
                     .textContent('Welcome to TutorialsPoint.com')
                     .ariaLabel('Welcome to TutorialsPoint.com')
                     .ok('Ok!')
                     .targetEvent(ev)
               );
            };
			
			
            $scope.showConfirm = function(event) {
               var confirm = $mdDialog.confirm()
                  .title('Are you sure to delete the record?')
                  .textContent('Record will be deleted permanently.')
                  .ariaLabel('TutorialsPoint.com')
                  .targetEvent(event)
                  .ok('Yes')
                  .cancel('No');
                  $mdDialog.show(confirm).then(function() {
                     $scope.status = 'Record deleted successfully!';
                     }, function() {
                        $scope.status = 'You decided to keep your record.';
                  });
            };
			
            $scope.showCustom = function(event) {
               $mdDialog.show({
                  clickOutsideToClose: true,
                  scope: $scope,        
                  preserveScope: true,           
            
                  templateUrl: '/panel/agregar_bodega',
                  controller: function DialogController($scope, $mdDialog) {
                     $scope.closeDialog = function() {
                        $mdDialog.hide();
                     }
                  }
               });
            };
         }


      
         app.controller('ExampleController', ['$scope', function ($scope) {
             debugger;
             $scope.loading = false;
             $scope.templates =
               [{ name: 'template1.html', url: 'demo/index1' },
                { name: 'template2.html', url: 'demo/mis_bodegas' },
               { name: 'template3.html', url: 'demo/informes' }];
             
             $scope.template = $scope.templates[0];
             $scope.boton = function (url) {
                 $scope.loading = true;
                 $scope.template = $scope.templates[url];
                 $scope.loading = false;
             };
         }]);

       app.controller('AppCtrl', function ($scope, $timeout, $mdSidenav, $log) {
           $scope.toggleLeft = buildDelayedToggler('left');
           $scope.toggleRight = buildToggler('right');
           $scope.isOpenRight = function () {
               return $mdSidenav('right').isOpen();
           };

           /**
            * Supplies a function that will continue to operate until the
            * time is up.
            */
           function debounce(func, wait, context) {
               var timer;

               return function debounced() {
                   var context = $scope,
                       args = Array.prototype.slice.call(arguments);
                   $timeout.cancel(timer);
                   timer = $timeout(function () {
                       timer = undefined;
                       func.apply(context, args);
                   }, wait || 10);
               };
           }

           /**
            * Build handler to open/close a SideNav; when animation finishes
            * report completion in console
            */
           function buildDelayedToggler(navID) {
               return debounce(function () {
                   // Component lookup should always be available since we are not using `ng-if`
                   $mdSidenav(navID)
                     .toggle()
                     .then(function () {
                         $log.debug("toggle " + navID + " is done");
                     });
               }, 200);
           }

           function buildToggler(navID) {
               return function () {
                   // Component lookup should always be available since we are not using `ng-if`
                   $mdSidenav(navID)
                     .toggle()
                     .then(function () {
                         $log.debug("toggle " + navID + " is done");
                     });
               };
           }
       })
       .controller('LeftCtrl', function ($scope, $timeout, $mdSidenav, $log) {
           $scope.close = function () {
               // Component lookup should always be available since we are not using `ng-if`
               $mdSidenav('left').close()
                 .then(function () {
                     $log.debug("close LEFT is done");
                 });

           };
       })
       .controller('RightCtrl', function ($scope, $timeout, $mdSidenav, $log) {
           $scope.close = function () {
               // Component lookup should always be available since we are not using `ng-if`
               $mdSidenav('right').close()
                 .then(function () {
                     $log.debug("close RIGHT is done");
                 });
           };
       });