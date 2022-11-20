﻿import React, { Component } from 'react';
import { DeleteOrderItem } from './DeleteOrderItem';

export class Order extends Component {
    static displayName = Order.name;
    constructor(props) {
        super(props)
        this.state = {
            id: new URLSearchParams(this.props.location.search).get("order_id"),
            orderItems: [],

            name: '',
            quantity: 0,
            unit: '',

            number: '',
            date: '',
            provider: null,

            loading: true
        }
    }

    getOrder = () => {
        const id = this.state.id
        fetch(`api/orders/${id}`)
            .then(e => {
                e.json().then(data => this.setState(
                    {
                        number: data.number,
                        date: data.date.substring(0, 10),
                        provider: data.provider,
                        orderItems: data.orderItems,
                        loading: false
                    }))
            })
    }

    getOrderItems = () => {
        this.setState({ loading: true })

        const orderId = this.state.id
        const name = this.state.name
        const unit = this.state.unit

        fetch(`api/orders/getOrderItems?orderId=${orderId}&name=${name}&unit=${unit}`)
            .then(e => {
                e.json().then(data => this.setState({ orderItems: data.items, loading: false }))
            })
    }

    addItemToOrder = (orderItem) => {
        const id = new URLSearchParams(this.props.location.search).get("order_id")
        fetch(`api/orders/${id}/addItemToOrder`,
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(orderItem)
            })
            .then(e => {
                this.getOrderItems()
            })
    }

    submit(e) {
        if (e.key == 'Enter')
            this.getOrderItems()
    }

    componentDidMount() {
        this.getOrder()
    }

    render() {
        return (
            <div>
                <div><h4>Информация о заказе №{this.state.number}</h4></div>
                <div><b>Номер:</b> {this.state.number}</div>
                <div><b>Дата:</b> {this.state.date ? new Date(this.state.date).toLocaleDateString() : ''}</div>
                <div><b>Поставщик:</b> {this.state.provider ? this.state.provider.name : null}</div>
                <div><b>Элементы заказа:</b></div>

                <div className="tool-bar">
                    <div className="filter">
                        <div className="item">
                            <input value={this.state.name} onKeyDown={(e) => this.submit(e)} onChange={(e) => this.setState({ name: e.target.value })} className="form-control" placeholder="Название" />
                        </div>
                        <div className="item">
                            <input value={this.state.unit} onKeyDown={(e) => this.submit(e)} onChange={(e) => this.setState({ unit: e.target.value })} className="form-control" placeholder="Величина" />
                        </div>
                        <div className="item">
                            <button onClick={() => this.getOrderItems()} className="btn btn-primary">Фильтр</button>
                        </div>
                    </div>
                    <button className="btn btn-success" onClick={() => this.props.history.push(`/orderitemform?order_id=${this.state.id}`)}>Добавить</button>
                </div>
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <td>№</td>
                            <td>Название</td>
                            <td>Количество</td>
                            <td>Величина</td>
                            <td className="tools"></td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.orderItems.map((o, index) =>
                                <tr key={index}>
                                    <td>{index + 1}</td>
                                    <td>{o.name}</td>
                                    <td>{o.quantity}</td>
                                    <td><b>{o.unit}</b></td>
                                    <td>
                                        <div className="table-tools">
                                            <button onClick={() => this.props.history.push(`/orderitem?order_id=${this.state.id}&id=${o.id}`)} className="btn btn-sm btn-default"><img src="./icons/view.png" /></button>
                                            <button onClick={() => this.props.history.push(`/orderitemform?order_id=${this.state.id}&id=${o.id}`)} className="btn btn-sm btn-default"><img src="./icons/pencil.png" /></button>
                                            <DeleteOrderItem id={o.id} updateData={this.getOrderItems}></DeleteOrderItem>
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