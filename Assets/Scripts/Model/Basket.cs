public class Basket
{
    public int col;
    public BasketView basketView;
    
    public void SetCol(int col)
    {
        this.col = col;
    }

    public void InitBasket(int col, BasketView basketView)
    {
        this.col = col;
        SetBasketView(basketView);
    }

    private void SetBasketView(BasketView basketView)
    {
        this.basketView = basketView;
    }   
}
