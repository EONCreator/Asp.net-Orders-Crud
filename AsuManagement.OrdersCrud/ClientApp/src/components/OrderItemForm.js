import React, { Component } from 'react';

export class OrderItemForm extends Component {
    static displayName = OrderItemForm.name;

    constructor(props) {
        super(props);
        this.state = {
            orderId: new URLSearchParams(this.props.location.search).get("order_id"),
            id: new URLSearchParams(this.props.location.search).get("id"),

            name: '',
            quantity: 0,
            unit: '',

            errors: []
        };
    }

    getOrderItem = () => {
        const id = this.state.id
        fetch(`api/orders/getOrderItem?id=${id}`)
            .then(e => {
                e.json().then(data => this.setState(
                    {
                        name: data.name,
                        quantity: data.quantity,
                        unit: data.unit
                    }))
            })
    }

    addOrderItem = (orderItem) => {
        const orderId = this.state.orderId
        fetch(`api/orders/${orderId}/addItemToOrder`,
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(orderItem)
            })
            .then(e => {
                e.json().then(data => {
                    if (data.errors)
                        this.setState({ errors: data.errors })
                    else
                        this.props.history.push(`/order?order_id=${orderId}`)
                })
            })
    }

    editOrderItem = (orderItem) => {
        const orderId = this.state.orderId
        const id = this.state.id
        fetch(`api/orders/editOrderItem/${id}`,
            {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(orderItem)
            })
            .then(e => {
                e.json().then(data => {
                    if (data.errors)
                        this.setState({ errors: data.errors })
                    else
                        this.props.history.push(`/order?order_id=${orderId}`)
                })
            })
    }

    componentDidMount() {
        const id = this.state.id
        if (id)
            this.getOrderItem()
    }

    render() {
        return (
            <div className="form">
                <div className="title"><h3>{this.state.id ? ('Редактирование элемента заказа "' + this.state.name + '"') : 'Добавление элемента к заказу'}</h3></div>
                <div className="row">
                    <div className="col-6 item">
                        <label>Название <span className="text-danger">*</span></label>
                        <input type="text" placeholder="Введите название" value={this.state.name} onChange={(e) => this.setState({ name: e.target.value })} />
                    </div>
                    <div className="col-6 item">
                        <label>Величина <span className="text-danger">*</span></label>
                        <input type="number" value={this.state.quantity} onChange={(e) => this.setState({ quantity: e.target.value })} />
                        <p className="error text-danger">{this.state.quantity >= 100 ? 'Недопустимое число' : null}</p>
                    </div>
                    <div className="col-6 item">
                        <label>Единица <span className="text-danger">*</span></label>
                        <input type="text" value={this.state.unit} onChange={(e) => this.setState({ unit: e.target.value })} />
                    </div>
                </div>
                <div className="form-tools">
                    <button className="btn btn-danger" onClick={() => this.props.history.push(`/order?order_id=${this.state.orderId}`)}>Отмена</button>
                    <button disabled={!this.state.unit || this.state.quantity > 100 || !this.state.name.length} className="btn btn-primary"
                        onClick={() =>
                            !this.state.id
                                ? this.addOrderItem(
                                    {
                                        name: this.state.name,
                                        quantity: this.state.quantity,
                                        unit: this.state.unit
                                    })
                                : this.editOrderItem(
                                    {
                                        name: this.state.name,
                                        quantity: this.state.quantity,
                                        unit: this.state.unit
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