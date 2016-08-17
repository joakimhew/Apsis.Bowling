(function () {
    "use strict";

    angular
        .module("app")
        .controller("ScoreController", scoreController);

    function scoreController($http) {
        var vm = this;


        vm.currentFrame = 0;
        vm.isCurrentFrameStrike = false;
        vm.isCurrentFrameSpare = false;

        vm.isLastFrame = false;
        vm.game = [];
        vm.game.frames = [];

        vm.updateFrames = updateFrames;

        vm.isFrameStrike = isFrameStrike;
        vm.isFrameSpare = isFrameSpare;

        initFrames();

        function initFrames() {
            for (var i = 0; i < 10; i++) {
                var frame = new Frame(null);

                if (i === 9)
                    frame.isLast = true;

                else
                    frame.isLast = false;

                vm.game.frames[i] = frame;
            }
        }

        function isFrameStrike(index) {
            var frame = vm.game.frames[index];

            var b1 = frame.first;

            if (parseInt(b1) === 10)
                return true;
            else
                return false;
        }

        function isFrameSpare(index) {

            if (isFrameStrike(index))
                return false;

            var frame = vm.game.frames[index];

            var b1 = frame.first;
            var b2 = frame.second;

            if (parseInt(b1) + parseInt(b2) === 10)
                return true;
            else
                return false;
        }
    

    function updateFrames() {

        vm.game.frames[vm.currentFrame].isFinished = true;

        $http({
            method: "post",
            url: "/score/submit",
            data: vm.game.frames
        })
            .success(function (data) {
                vm.game = data;
                vm.currentFrame += 1;
                vm.isLastFrame = vm.currentFrame === 9 ? true : false;
                vm.isCurrentFrameStrike = false;

                for (var i = vm.currentFrame; i < vm.game.frames.length; i++) {
                    vm.game.frames[i].first = null;
                    vm.game.frames[i].second = null;
                    vm.game.frames[i].third = null;
                    vm.game.frames[i].framescore = null;
                }
            });
    }

}

})();

var Game = class game {
    constructor(frames, score, numberOfRounds) {
        this.frames = frames;
        this.score = score;
        this.numberOfRounds = numberOfRounds;
    }
}

var Frame = class frame {
    constructor(first, second, third, framescore, isSpare, isStrike, isFinished, isLast) {
        this.first = first;
        this.second = second;
        this.third = third;
        this.framescore = framescore;
        this.isSpare = isSpare;
        this.isSrike = isStrike;
        this.isFinished = isFinished;
        this.isLast = isLast;
    }
};