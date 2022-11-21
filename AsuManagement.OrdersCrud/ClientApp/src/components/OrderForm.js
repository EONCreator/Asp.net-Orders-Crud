import React, { Component } from 'react';

export class OrderForm extends Component {
    static displayName = OrderForm.name;

    constructor(props) {
        super(props);
        this.state = {
            id: new URLSearchParams(this.props.location.search).get("order_id"),
            providers: [],

            number: '',
            date: new Date().toISOString().substring(0, 10),
            providerId: 0,

            errors: []
        };
    }

    getProviders = () => {
        fetch(`api/providers/`)
            .then(e => {
                e.json().then(data => this.setState({ providers: data.items, providerId: data.items.length ? data.items[0].id : null }))
            })
    }

    getOrder = () => {
        const id = this.state.id
        fetch(`api/orders/${id}`)
            .then(e => {
                e.json().then(data => {
                    this.setState(
                    {
                        number: data.number,
                        date: data.date.substring(0, 10),
                        providerId: data.providerId
                    })
                }
                )
            })
    }

    addOrder = (order) => {
        fetch(`api/orders`,
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            })
            .then(e => {
                e.json().then(data => {
                    if (data.errors)
                        this.setState({ errors: data.errors })
                    else
                        this.props.history.push('/')
                })
            })
        
    }

    editOrder = (order) => {
        const id = this.state.id
        fetch(`api/orders/${id}`,
            {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            })
            .then(e => {
                e.json().then(data => {
                    if (data.errors)
                        this.setState({ errors: data.errors })
                    else
                        this.props.history.push('/')
                })
            })
    }

    componentWillMount() {
        this.getProviders()
    }

    componentDidMount() {
        const id = this.state.id
        if (id)
            this.getOrder()
    }

    render() {
        return (
            <div className="form">
                <div className="title"><h3>{this.state.id ? ('Редактирование заказа №' + this.state.number) : 'Добавление заказа'}</h3></div>
                <div className="row">
                    <div className="col-6 item">
                        <label>Номер <span className="text-danger">*</span></label>
                        <input placeholder="Номер" value={this.state.number} onChange={(e) => this.setState({ number: e.target.value })} />
                    </div>
                    <div className="col-6 item">
                        <label>Дата <span className="text-danger">*</span></label>
                        <input type="date" value={this.state.date} onChange={(e) => this.setState({ date: e.target.value })} />
                    </div>
                    <div className="col-6 item">
                        <label>Поставщик <span className="text-danger">*</span></label>
                        <select placeholder="Номер" value={this.state.providerId} onChange={(e) => this.setState({ providerId: e.target.value })}>
                            {
                                this.state.providers.map((p, index) => <option key={index} value={p.id}>{p.name}</option>)
                            }
                        </select>
                    </div>
                </div>
                <div className="form-tools">
                    <button className="btn btn-danger" onClick={() => this.props.history.push(`/`)}>Отмена</button>
                    <button disabled={!this.state.providerId && !this.state.number.length} className="btn btn-primary"
                        onClick={() =>
                            !this.state.id
                                ? this.addOrder(
                                    {
                                        number: this.state.number,
                                        date: this.state.date,
                                        providerId: this.state.providerId
                                    })
                                : this.editOrder(
                                    {
                                        number: this.state.number,
                                        date: this.state.date,
                                        providerId: this.state.providerId
                                    })
                        }>OK</button>
                </div>
                <div className="errors-list">
                    {
                        this.state.errors.map(e => <div className="error-item">{e}</div>)
                    }
                </div>
            </div>
        );
    }
}