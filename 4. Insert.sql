USE [RecipeBookSystemTestDB];
GO

--Adding test user.
EXEC spUsers_Add 'TestUser', 'test@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055';


--Adding product types
EXEC spProductType_Add 'Fish', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326464/kzmh7l9e1d2qlrhamapq.png', NULL;
EXEC spProductType_Add 'Meat', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326507/qex3tsixufmhk0x5bc9u.png', NULL;
EXEC spProductType_Add 'Dairy products', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326564/vvicm31ucws0rtppisjc.png', NULL;
EXEC spProductType_Add 'Vegetables', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326633/ipkbeouqxhgxikcac4mo.png', NULL;
EXEC spProductType_Add 'Fruits', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326740/q0y79yiqh9kg0uu9krmu.png', NULL;
EXEC spProductType_Add 'Nuts', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326974/c0lxkb20xmenllqbbqir.png', NULL;
EXEC spProductType_Add 'Crops', 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475326381/r0lgn6ffcvv4t5k48w1v.png', NULL;

--Adding fish
EXEC spProduct_AddNew 'Perch', 1, 18.5, 0.9, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475329855/xj0vvqiscv9jgzofrejd.png', NULL;
EXEC spProduct_AddNew 'Salmon', 1, 21.8, 9.7, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475329993/ncvk0ek0zk3zh1vusvcf.png', NULL;
EXEC spProduct_AddNew 'Cod', 1, 17.5, 0.6, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475330330/alvglmzpjlrfkzvhehpi.png', NULL;
EXEC spProduct_AddNew 'Tuna', 1, 22, 4, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475330528/pyc8uanb6alfb5vygtb8.png', NULL;
EXEC spProduct_AddNew 'Pike', 1, 18.8, 0.7, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475330634/xbwvfrz9xiymmdie0mks.png', NULL;
EXEC spProduct_AddNew 'Carp', 1, 16, 3.6, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475331048/gktzhbnuiezpowbh8dcl.png', NULL;
EXEC spProduct_AddNew 'Cartfish', 1, 16.5, 11.9, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475331329/drlqtxbbiafbc5fgjn7a.png', NULL;

--Adding meat
EXEC spProduct_AddNew 'Rabbit', 2, 20.7, 12.9, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475331739/pjklqsre8cep9eflzib8.png', NULL;
EXEC spProduct_AddNew 'Elk', 2, 21.4, 1.7, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475331922/r35laiidaoillw7dffqm.png', NULL;
EXEC spProduct_AddNew 'Mutton', 2, 20.8, 9, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475332509/lytga1ju2ea2xwkbymvn.png', NULL;
EXEC spProduct_AddNew 'Beef', 2, 18.9, 12.4, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475332578/gmfkurrbvhxvwjpucds0.png', NULL;
EXEC spProduct_AddNew 'Pork', 2, 16.4, 27.8, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475332628/pvkih4yz8dqcbknw3uxn.png', NULL;
EXEC spProduct_AddNew 'Veal', 2, 19.7, 1.2, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475332671/pxs4flii65o1tbc99kkk.png', NULL;

--Adding Dairy products  
EXEC spProduct_AddNew 'Milk', 3, 2.8, 3.2, 4.7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475341402/cwnssxibxaubqhiodrnl.png', NULL;
EXEC spProduct_AddNew 'Low-fat milk', 3, 3, 0.05, 4.7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475342206/opxl3vqlasz5snz7xop5.png', NULL;
EXEC spProduct_AddNew 'Cottage cheese', 3, 14, 18, 0.13, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475342780/okulomo69616jzcm5sq1.png', NULL;
EXEC spProduct_AddNew 'Yogurt', 3, 5, 1.5, 3.5, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475342983/aaxbxdo1syznkiz1o3t2.png', NULL;
EXEC spProduct_AddNew 'Dutch cheese', 3, 23.5, 30.9, 0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475343172/ldr3reneat36aw5yipxm.png', NULL;
EXEC spProduct_AddNew 'Sour cream', 3, 2.8, 20, 3.2, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475343310/fuqmmycvlmh5ebqmeobo.png', NULL;
EXEC spProduct_AddNew 'Kefir', 3, 2.8, 3.2, 4.1,'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475343559/wdlfrtt1lr7b6rhjgixf.png', NULL;
EXEC spProduct_AddNew 'Low-fat kefir', 3, 3, 0.05, 3.8, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475343647/jj5pvnukm0bubignzfs0.png', NULL;

--Adding Vegetables
EXEC spProduct_AddNew 'Eggplant', 4, 0.6, 0.1, 5.5, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475346770/fjsoxdmno9uvfw7mlkl5.png', NULL;
EXEC spProduct_AddNew 'Beans', 4, 6, 0.1, 8.3, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475346802/scqbqpadazmdiwu5q79u.png', NULL;
EXEC spProduct_AddNew 'Green peas', 4, 5, 0.2, 13.3, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475346933/cja5waneoxllfeypncpx.png', NULL;
EXEC spProduct_AddNew 'Potato', 4, 2, 0.2, 19.7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347002/q7nzbjgp2e9pbl47esz4.png', NULL;
EXEC spProduct_AddNew 'Cabbage', 4, 1.8, 0.3, 5.4, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347111/gmdkunlgciqtyjdu9qfg.png', NULL;
EXEC spProduct_AddNew 'Onion', 4, 3, 0.3, 7.3, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347178/umu7tujf6wk218itfj2m.png', NULL;
EXEC spProduct_AddNew 'Carrot', 4, 1.3, 0.5, 7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347207/gpk6droxqnqi4sziqihn.png', NULL;
EXEC spProduct_AddNew 'Cucumbers', 4, 0.8, 0.2, 3.0, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347260/ulj9scezgtswz2peph8s.png', NULL;
EXEC spProduct_AddNew 'Sweet pepper', 4, 1.3, 0.1, 5.7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347323/ugkdt5xkotwezhrh5stx.png', NULL;
EXEC spProduct_AddNew 'Parsley', 4, 3.7, 0.2, 8.1, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347375/z6llwadfaqlea1mlbeuz.png', NULL;
EXEC spProduct_AddNew 'Radish', 4, 1.2, 0.1, 4.1, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347426/ulgo8meakzamgiam7ada.png', NULL;
EXEC spProduct_AddNew 'Garlic', 4, 6.5, 0.1, 21.2, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475347465/sfzxngjeej6wxkpon5h2.png', NULL;

--Adding Fruits
EXEC spProduct_AddNew 'Abricots', 5, 0.9, 0, 10.5, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475348591/ot0v8cnwlrjnsl5rkwyj.png', NULL;
EXEC spProduct_AddNew 'Ananas', 5, 0.4, 0, 11.8, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475348623/qhptwn5a8p9tv2oh6vha.png', NULL;
EXEC spProduct_AddNew 'Bananas', 5, 1.5, 0, 22.4, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475348685/lfcewlzery2xqub1m503.png', NULL;
EXEC spProduct_AddNew 'Cherry', 5, 0.8, 0, 11.3,  'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475348769/bbkiz1al4w4fwnx9h64g.png', NULL;
EXEC spProduct_AddNew 'Garnet', 5, 0.9, 0, 11.8,  'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475348900/ilixkkbodptfpyrdnhwt.png', NULL;
EXEC spProduct_AddNew 'Peach', 5, 0.9, 0, 10.4,  'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349519/d9weo7c8vztyxfzuomoy.png', NULL;
EXEC spProduct_AddNew 'Apple', 5, 0.4, 0, 11.3,  'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349592/stz32js3pvaxh5nxad3s.png', NULL;
EXEC spProduct_AddNew 'Watermelon', 5, 0.7, 0.4, 9.2, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349669/ooczvhbcxgce1jj06r51.png', NULL;
EXEC spProduct_AddNew 'Melon', 5, 0.6, 0.1, 9.6, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349717/r3jgcbycbal0dnrohcb5.png', NULL;
EXEC spProduct_AddNew 'Orange', 5, 0.9, 0, 8.4, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349901/vwgufkxeo7cnaq0dbq6o.png', NULL;
EXEC spProduct_AddNew 'Mandarin', 5, 0.8, 0, 8.1, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475349935/qt4lfsa8vtwlr66ijfdb.png', NULL;
EXEC spProduct_AddNew 'Grape', 5, 0.4, 0, 17.5, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475350005/zyva8ohiwitbpimvjysp.png', NULL;
EXEC spProduct_AddNew 'Strawberry', 5, 1.8, 0, 8.1, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475350053/ej6mswvxuuuwh6klgzyp.png', NULL;
EXEC spProduct_AddNew 'Raspberry', 5, 0.8, 0, 9, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475350101/dpxuwbcr1jfbyosv1vu7.png', NULL;

--Adding Nuts
EXEC spProduct_AddNew 'Hazelnut', 6, 16.1, 66.9, 9.9, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475354769/jehkal49kmoctgf0zrrj.png', NULL;
EXEC spProduct_AddNew 'Almond', 6, 18.6, 57.7, 13.6, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475354814/pod6qyidsxdti050aa6u.png', NULL;
EXEC spProduct_AddNew 'Walnut', 6, 13.8, 61.3, 10.2, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475354853/izlmxzfuoljthmbsdn18.png', NULL;
EXEC spProduct_AddNew 'Peanut', 6, 26.3, 45.2, 9.7, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475354885/ecbn0zz7vwty9vftykb1.png', NULL;
EXEC spProduct_AddNew 'Sunflower seed', 6, 20.7, 52.9, 5, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475354927/rndjgjxpkmqecx25xioc.png', NULL;

--Adding Crops
EXEC spProduct_AddNew 'Rice', 7, 7.3, 2, 63.1, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475356395/qkwfs2y3f2ahwem0g1h6.png', NULL;
EXEC spProduct_AddNew 'Munk', 7, 11.3, 0.7, 73.3, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475356453/dsjfoy1cn2zvwmjuq0st.png', NULL;
EXEC spProduct_AddNew 'Buckwheat', 7, 9.5, 1.9, 72.2, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475356526/izdtydbsrupdhgacs20n.png', NULL;
EXEC spProduct_AddNew 'Oat', 7, 11.9, 5.8, 65.4, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475356639/xifos4tnurwrukdarzdz.png', NULL;
EXEC spProduct_AddNew 'Bread', 7, 7.7, 2.4, 53.4, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475356674/buj4uqvuksdd6vz9uwiy.png', NULL;


--Adding Dishes and their ingredients to test user(with 1 id value)
DECLARE @DishId INT;

EXEC spDish_Add 'Buckwheat with milk', 1, 'Healthy food that will give you a boost of energy', NULL, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1476549112/lbqqxbqeqhswy1zxyoy5.png', @DishId OUT;
EXEC spIngredient_Add @DishId, 55, 100;
EXEC spIngredient_Add @DishId, 15, 150;

EXEC spDish_Add 'Potato with meat', 1, NULL, NULL, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1475928152/vgmot2qiwbhihmm35kew.png', @DishId OUT;
EXEC spIngredient_Add @DishId, 25, 500;
EXEC spIngredient_Add @DishId, 12, 200;

EXEC spDish_Add 'Protein shake with bananas', 1, 'A delicious cocktail that will help you to gain weight', NULL, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1476548441/x9rgkirah1xx5fkgbbon.png', @DishId OUT;
EXEC spIngredient_Add @DishId, 16, 300;
EXEC spIngredient_Add @DishId, 14, 200;
EXEC spIngredient_Add @DishId, 36, 100;
EXEC spIngredient_Add @DishId, 56, 50;

EXEC spDish_Add 'Rice with vegetables', 1, 'Good and tasty dish which is easy to prepare', NULL, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1476365705/jcl6liovchdvi2fardiy.png', @DishId OUT;
EXEC spIngredient_Add @DishId, 53, 200;
EXEC spIngredient_Add @DishId, 28, 20;
EXEC spIngredient_Add @DishId, 27, 15;
EXEC spIngredient_Add @DishId, 24, 40;

EXEC spDish_Add 'Сottage cheese with bananas', 1, NULL, NULL, 'https://res.cloudinary.com/dubbhhxmr/image/upload/v1476366500/tf0lvf2nh1kz8zoxj1jp.png', @DishId OUT;
EXEC spIngredient_Add @DishId, 36, 300;
EXEC spIngredient_Add @DishId, 16, 400;
GO




