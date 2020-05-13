new Vue({
    el: '#calc-app',
    data: {
        firstNumber: 0,
        secondNumber: 0,
        calculatorResult: 0,
        firstNumberDesc: 'Start',
        secondNumberDesc: 'Amount',
        operation: 'add',
        errorMessage: null
    },
    methods: {
        calc: function () {
            var vm = this;

            var url = "https://localhost:44362/api/calculator/" + this.operation;

            var req = {};
            switch (this.operation) {
                case "add":
                    req = {
                        start: parseFloat(vm.firstNumber),
                        amount: parseFloat(vm.secondNumber)
                    };
                    break;
                case "subtract":
                    req = {
                        start: parseFloat(vm.firstNumber),
                        amount: parseFloat(vm.secondNumber)
                    };
                    break;
                case "multiply":
                    req = {
                        start: parseFloat(vm.firstNumber),
                        by: parseFloat(vm.secondNumber)
                    };
                    break;
                case "divide":
                    req = {
                        nominator: parseFloat(vm.firstNumber),
                        denominator: parseFloat(vm.secondNumber)
                    };
                    break;
            }

            axios.post(url, req)
                .then(function (response) {
                    console.log('POST success');
                    console.log(JSON.stringify(response));
                    vm.calculatorResult = response.data;
                })
                .catch(function (error) {
                    console.log('POST failed');
                    console.log(error);
                    vm.errorMessage = error;
                });
        },
        pickOperation: function (op) {
            this.operation = op;
            switch (this.operation) {
                case "add":
                    this.firstNumberDesc = "Start";
                    this.secondNumberDesc = "Amount";
                    break;
                case "subtract":
                    this.firstNumberDesc = "Start";
                    this.secondNumberDesc = "Amount";
                    break;
                case "multiply":
                    this.firstNumberDesc = "Start";
                    this.secondNumberDesc = "By";
                    break;
                case "divide":
                    this.firstNumberDesc = "Numerator";
                    this.secondNumberDesc = "Denominator";
                    break;
            }
        },
        clear: function () {
            this.calculatorResult = 0;
        },
        test: function () {
            this.calculatorResult = 444;
        }
    },
    created: function () {
        this.pickOperation('add');
    }
});
