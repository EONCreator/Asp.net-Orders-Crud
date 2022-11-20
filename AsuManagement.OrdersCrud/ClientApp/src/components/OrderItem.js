import React, { Component } from 'react';

export class OrderItem extends Component {
    static displayName = OrderItem.name;
    constructor(props) {
        super(props)
        this.state = {
            orderId: new URLSearchParams(this.props.location.search).get("order_id"),
            id: new URLSearchParams(this.props.location.search).get("id"),

            name: '',
            quantity: null,
            unit: ''
        }
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

    componentDidMount() {
        this.getOrderItem()
    }

    render() {
        return (
            <div>
                <div><h4>Информация об элементе заказа {this.state.name}</h4></div>
                <div><b>Название:</b> {this.state.name}</div>
                <div><b>Количество:</b> {this.state.quantity}</div>
                <div><b>Величина:</b> {this.state.unit}</div>

                <div className="form-tools" onClick={() => this.props.history.push(`/order?order_id=${this.state.orderId}`)}>
                    <button className="btn btn-danger">Назад</button>
                </div>
            </div>
        );
    }
}