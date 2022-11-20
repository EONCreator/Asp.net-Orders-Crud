import React, { Component } from 'react';
import { DeleteOrder } from './DeleteOrder';

export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = {
            orders: [],
            providers: [],

            number: '',
            date: new Date(),
            dateFrom: null,
            dateTo: null,
            providerId: null,

            loading: false
        }
    }

    //For UI
    getProviders = () => {
        fetch(`api/providers/`)
            .then(e => {
                e.json().then(data => this.setState({ providers: data.items }))
            })
    }

    getOrders = () => {
        this.setState({ loading: true })

        const number = this.state.number
        const dateFrom = this.state.dateFrom
        const dateTo = this.state.dateTo
        const providerId = this.state.providerId

        let filterString = `number=${number}`;

        if (providerId)
            filterString = filterString + `&providerId=${providerId}`

        if (dateFrom)
            filterString = filterString + `&dateFrom=${dateFrom}`

        if (dateTo)
            filterString = filterString + `&dateTo=${dateTo}`
            
        fetch(`api/orders?${filterString}`)
            .then(e => {
                e.json().then(data => this.setState({ orders: data.items, loading: false }))
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

    componentWillMount() {
        this.getProviders()
    }

    componentDidMount() {
        this.getOrders()
    }

    render() {
        return (
            <div>
                <div className="tool-bar">
                    <div className="filter">
                        <div className="item">
                            <input value={this.state.number} onChange={(e) => this.setState({ number: e.target.value })} className="form-control" placeholder="Номер" />
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