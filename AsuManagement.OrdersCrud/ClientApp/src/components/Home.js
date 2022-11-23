import React, { Component } from 'react';
import { DeleteOrder } from './DeleteOrder';

export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = {
            orders: [],
            numbers: [],
            providers: [],

            number: '',
            date: new Date(),
            dateFrom: null,
            dateTo: null,
            providerId: null,

            numbersToFilter: [],
            providersToFilter: [],

            showNumbersFilter: false,
            showProvidersFilter: false,

            loading: false
        }
    }

    getOrders = () => {
        this.setState({ loading: true })

        const numbers = this.state.numbersToFilter
        const dateFrom = this.state.dateFrom
        const dateTo = this.state.dateTo
        const providerId = this.state.providerId

        let filterString = ``;

        if (numbers.length)
            filterString = filterString + `numbers=${numbers}`

        if (providerId)
            filterString = filterString + `&providerId=${providerId}`

        if (dateFrom)
            filterString = filterString + `&dateFrom=${dateFrom}`

        if (dateTo)
            filterString = filterString + `&dateTo=${dateTo}`
            
        fetch(`api/orders?${filterString}`)
            .then(e => {
                e.json().then(data => this.setState(
                { 
                    orders: data.items,
                    numbers: data.numbers,
                    providers: data.providers,
                    loading: false 
                }))
            })
    }

    initProperties() {
        var newDate = new Date()
        newDate.setMonth(newDate.getMonth() - 1)
        this.setState({ dateFrom: newDate.toISOString().substring(0, 10) })

        this.setState({ 
            dateFrom: new Date().toISOString().substring(0, 10),
            dateTo: new Date().toISOString().substring(0, 10) 
        })
    }

    componentDidMount() {
        this.getOrders()

        let obj = this
        document.body.onclick = function (event) {
            console.log(event)
            if (event.target.className != "multiple-select")
                if (!obj.state.showNumbersFilter)
                    obj.setState({ showNumbersFilter: false })
        }
    }

    setNumbersToFilter(e) {
        this.setState({ numbersToFilter: [] })

        var numbers = []
        var options = e.target.options;
        for (var i = 0, l = options.length; i < l; i++) {
            if (options[i].selected) {
                numbers.push(options[i].value)
                this.setState({ numbersToFilter: numbers });
            }
        }
    }

    render() {
        return (
            <div>
                <div className="tool-bar">
                    <div className="filter">
                        <div className="item" id="numberFiltersButton">
                            <button className="filter-button">Номера<img src="./icons/arrow-down.png" /></button>
                            <select className="multiple-select" id="numberFilter" multiple
                                onChange={(e) => this.setNumbersToFilter(e)}>
                                    {
                                        this.state.numbers.map((e) => <option key={e} value={e}>{e}</option>)
                                    }
                            </select>
                        </div>
                        <div className="item">
                            <label>Поставщик</label>
                            <select value={this.state.providerId} onChange={(e) => this.setState({ providerId: e.target.value })}>
                                <option value={0}>Все</option>
                                {
                                    this.state.providers.map((e) => <option key={e.id} value={e.id}>{e.name}</option>)
                                }
                            </select>
                        </div>
                        <div className="item">
                            <label>От</label>
                            <input type="date" value={this.state.dateFrom} onChange={(e) => this.setState({ dateFrom: e.target.value })} />
                        </div>
                        <div className="item">
                            <label>До</label>
                            <input type="date" value={this.state.dateTo} onChange={(e) => this.setState({ dateTo: e.target.value })} />
                        </div>
                        <div className="item">
                            <button onClick={() => this.getOrders()} className="btn btn-primary">Фильтр</button>
                        </div>
                    </div>
                    <button className="btn btn-success" onClick={() => this.props.history.push('/orderform')}>Добавить</button>
                </div>
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <td>№</td>
                            <td>Номер заказа</td>
                            <td>Дата</td>
                            <td>Поставщик</td>
                            <td className="tools"></td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.orders.map((o, index) =>
                                <tr key={index}>
                                    <td>{index + 1}</td>
                                    <td>{o.number}</td>
                                    <td>{new Date(o.date).toLocaleDateString()}</td>
                                    <td>{o.provider.name}</td>
                                    <td>
                                        <div className="table-tools">
                                            <button onClick={() => this.props.history.push(`/order?order_id=${o.id}`)} className="btn btn-sm btn-default"><img src="./icons/view.png" /></button>
                                            <button onClick={() => this.props.history.push(`/orderform?order_id=${o.id}`)} className="btn btn-sm btn-default"><img src="./icons/pencil.png" /></button>
                                            <DeleteOrder id={o.id} updateData={this.getOrders}></DeleteOrder>
                                        </div>
                                    </td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>
                {
                    this.state.loading ?
                        <div className="loading">
                            <p>Подождите, идет загрузка...</p>
                        </div> : null
                }
            </div>
        );
    }
}