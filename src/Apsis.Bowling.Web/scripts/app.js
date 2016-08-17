//(function() {
//    "use strict";

//    angular
//        .module("app")
//        .controller("ScoreController", scoreController);

//    function scoreController($http) {
//        var vm = this;
//        var numberOfRounds = 10;

//        vm.currentRound = 0;
//        vm.frames = getFrames();

//        vm.submitFrame = function(firstBall, secondBall, thirdBall) {
//            vm.frames[currentRound].first = firstBall;
//            vm.frames[currentRound].second = secondBall;
//            vm.frames[currentRound].third = thirdBall;

//            vm.submitFrames();
//        }

//        vm.submitFrames = function () {
//            $http({
//                method: "POST",
//                url: "/score/submit",
//                data: $scope.frames
//            })
//                .success(function (data) {
//                    $scope.frames = data;
//                });
//        }

//        var getFrames = function () {
//            var f = [];
//            for (var i = 0; i < numberOfRounds; i++) {
//                f[i] = new Frame(null, null, null);
//            }
//            return f;
//        }
//    }
//});

//var Frame = class frame {
//    constructor(first, second, third, framescore, isSpare, isStrike, isFinished) {
//        this.first = first;
//        this.second = second;
//        this.third = third;
//        this.framescore = framescore;
//        this.isSpare = isSpare;
//        this.isStrike = isStrike;
//        this.isFinished = isFinished;
//    }
//}