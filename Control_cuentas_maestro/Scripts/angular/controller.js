

        


app.controller('modals', ['$scope', 'mantenedor_total', function ($scope ,mantenedor_total) {

    $scope.abremodal = function (url, id) {
        mantenedor_total.modal(url, id, $scope);
    };
}]);
app.controller('login', ['$scope', 'mantenedor_total', function ($scope, mantenedor_total) {

    $scope.login = function () {

        var personas = { 'correo_electronico_persona': $scope.logins.correo_electronico_persona, 'clave_persona': $scope.logins.clave_persona };
        var add_emp = mantenedor_total.agregar_datos('/login/login', personas);
        add_emp.then(function (successResponse) {
            if (successResponse.data.success == true) {
                window.location.pathname = successResponse.data.respuesta; 


            } else {
                $scope.respuesta = successResponse.data.respuesta;
            }
        
           
        },
        function (errorResponse) {
            console.log("error login")
        });
    };


}]);

      
         app.controller('ExampleController', ['$scope', function ($scope) {
           
             $scope.loading = false;
             $scope.templates =
               [{ name: 'template1.html', url: '../menu/vista1' },
                { name: 'template2.html', url: '../menu/vista2' },
               { name: 'template3.html', url: '../menu/vista3' }];
             
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