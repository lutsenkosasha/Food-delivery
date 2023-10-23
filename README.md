# Food-delivery

# Регистрация
Пользователь обязан зарегистрироваться в системе, предоставив свои данные ФИО, номер телефона.
В дальнейшем он будет авторизовываться по номеру телефона.

# Главная страница
После того, как пользователь зарегистрировался, перед ним открывается список ресторанов, из которых он может заказать еду.
Доставка осуществляется только из одного ресторана (из 2-ух ресторанов в один заказ нельзя будет заказать).
После выбора ресторана пользователю предоставляется меню в виде карточек с блюдами.
На карточке есть информация с названием блюда, кратким описанием, граммовками и ценой.
По выбору блюда - оно падает в корзину. В дальнейшем, когда пользователь все выбрал, он переходит в корзину, где указывает дополнительные данные, такие как: полный адрес куда доставлять (может указать как свой адрес, так и отправить заказ домой другу, например), и предоставляет данные платежной карты (через Яндекс Пей сделаем оплату).
После этого он увидит сообщение о том, что заказ принят и время доставки заказа.

# Личный кабинет
У пользователя в правом верхнем углу экрана будет иконка его личного кабинета. В личном кабинете он может изменять свои данные: иконка, ФИО, номер телефона, может добавить новую платежную карту, может удалить старую карту, может отметить свой постоянный адрес, на который заказывает (в этом случае, когда пользователь положил еду в корзину, ему не придется вписывать данные адреса и платежной карты - эта информация достанется из личного кабинета. Если же хочет заказать на другой адрес и оплатить другой картой - он сможет ввести данные, когда будет находиться в корзине).

# Возможности
Пользователь имеет возможность отфильтровать рестораны и магазины, например, по времени ожидания (допустим пользователь готов подождать курьера край 25 минут).

# Админка
В систему можно зайти как администратор, имея пароль. 
Администратор имеет возможность ограничить доступ определенному пользователю к заказам.
Администратор имеет право добавлять новые рестораны, новые блюда, изменять информацию о блюдах, изменять информацию о ресторанах.
Администратор имеет возможность удалять рестораны, блюда.
